using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PeliculasAPI.DistributedServices.Services.Inter;
using PeliculasAPI.Domain;
using PeliculasAPI.Domain.Entidades;
using PeliculasAPI.Domain.Entidades.DTO;
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
        private readonly IMapper mapper;

        public GenerosController(ILogger<GenerosController> logger, IGeneroService generoService,
            IMapper mapper)
        {            
            this.logger = logger;
            this.generoService = generoService;
            this.mapper = mapper;
        }

        [HttpGet] // api/generos
        public async Task<ActionResult<List<GeneroDTO>>> Get()
        {
            var generos = await generoService.GetAll();
            return mapper.Map<List<GeneroDTO>>(generos);

        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<GeneroDTO>> Get(int Id)
        {
            var genero = await generoService.GetById(Id);
            return mapper.Map<GeneroDTO>(genero);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateGeneroDTO genero)
        {
            var generoCreateDTO = mapper.Map<Genero>(genero);
            await generoService.Insert(generoCreateDTO);                        
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genero genero)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(GeneroDTO generoDelete)
        {
            await generoService.Delete(generoDelete.Id);
            return NoContent();
        }

    }
}
