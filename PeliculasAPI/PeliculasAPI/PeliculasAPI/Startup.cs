using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PeliculasAPI.DistributedServices.APIBehavior;
using PeliculasAPI.Domain;
using PeliculasAPI.DistributedServices.Filtros;
using PeliculasAPI.Domain.Repos.Interfaces;
using PeliculasAPI.Domain.Repos.Impl.GeneroRepository;
using PeliculasAPI.DistributedServices.Services.Inter;
using PeliculasAPI.DistributedServices.Services.Impl;
using Refit;
using PeliculasAPI.ServiceInfo;
using System.Linq;

namespace PeliculasAPI
{

    public class AppConfig : IAppConfig
    {
        public IAppConfig.IConnectionStrings connectionStrings{ get; set; }        

        public class ConnectionStrings : IAppConfig.IConnectionStrings
        {
            public string defaultConnection { get; set; }
        }
    }

    public interface IAppConfig
    {
        IConnectionStrings connectionStrings { get; }

        interface IConnectionStrings
        {
            string defaultConnection { get; }
        }
    }



    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Adding AutoMapper for my DTOs
            services.AddAutoMapper(typeof(Startup));

            services.AddRefitClients();

            // Adding my DbContext                                 
            services.AddDbContext<PeliculasAPIDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

            //Repos
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            //Service
            services.AddScoped<IGeneroService, GeneroService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(FiltroDeExcepcion));
                options.Filters.Add(typeof(ParseBadRequest));
                //options.Filters.Add(typeof(ActionFilter2));
            }).ConfigureApiBehaviorOptions(BehaviorBadRequest.Parse);

            services.AddCors(options =>
            {
                string frontendURL = Configuration.GetSection("Logging:frontEnd_url").Get<string>();

                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader()
                    .WithExposedHeaders(new string[] { "totalRecords" });
                });
                
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PeliculasAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PeliculasAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
