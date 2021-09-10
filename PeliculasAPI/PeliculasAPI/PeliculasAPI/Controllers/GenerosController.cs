using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PeliculasAPI.DistributedServices.Services.Inter;
using PeliculasAPI.Domain;
using PeliculasAPI.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Controllers
{
    [Route("api/generos")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenerosController : ControllerBase
    {              
        private readonly ILogger<GenerosController> logger;
        private readonly IGeneroService generoService;

        public GenerosController(ILogger<GenerosController> logger, IGeneroService generoService)
        {            
            this.logger = logger;
            this.generoService = generoService;
        }

        [HttpGet] // api/generos
        public async Task<ActionResult<List<Genero>>> Get()
        {
            return await generoService.GetAll();
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Genero>> Get(int Id)
        {
            return await generoService.GetById(Id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Genero genero)
        {
            await generoService.Insert(genero);                        
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            await generoService.Delete(Id);
            return NoContent();
        }

    }
}
