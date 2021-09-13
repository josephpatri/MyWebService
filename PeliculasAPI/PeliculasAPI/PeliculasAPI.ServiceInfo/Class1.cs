using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PeliculasAPI.Domain.Entidades.DTO;
using Refit;

namespace PeliculasAPI.ServiceInfo
{    
    public interface IApiClient
    {
        [Get("/api/generos")]        
        Task<ApiResponse<List<GeneroDTO>>> Get();
    }

    public static class RefitIoC
    {
        public static IServiceCollection AddRefitClients(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddRefitClient<IApiClient>().ConfigureHttpClients();
            return serviceDescriptors;
        }
        
        public static IHttpClientBuilder ConfigureHttpClients(this IHttpClientBuilder clientBuilder)
        {
            clientBuilder.ConfigureHttpClient(c => {
                c.BaseAddress = new Uri("https://localhost:5001");
                c.DefaultRequestHeaders.TryAddWithoutValidation("Origin", "http://localhost:3000");                
            });
            return clientBuilder;
        }
    }
}
