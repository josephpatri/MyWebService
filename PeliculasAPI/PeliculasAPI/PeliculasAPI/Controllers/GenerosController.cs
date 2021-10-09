using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PeliculasAPI.DistributedServices.Extensions;
using PeliculasAPI.DistributedServices.Filtros;
using PeliculasAPI.DistributedServices.Services.Inter;
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
    [EnableCors()]
    public class GenerosController : ControllerBase
    {
        private readonly ILogger<GenerosController> logger;
        private readonly IMapper mapper;
        private readonly IGeneroService generoService;

        public GenerosController(ILogger<GenerosController> logger, IGeneroService generoService,
            IMapper mapper)
        {
            this.logger = logger;
            this.generoService = generoService;
            this.mapper = mapper;
        }

        [HttpGet] // api/generos   
        public async Task<ActionResult<List<GeneroDTO>>> Get([FromQuery] PaginationDTO pagination)
        {
            var query = generoService.BuidQuery();
            await HttpContext.InsertPaginationHeadersParams(query);
            var generos = await query.OrderBy(x => x.Nombre).Paginate(pagination).ToListAsync();
            return mapper.Map<List<GeneroDTO>>(generos);

        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<GeneroDTO>> Get(int Id)
        {
            var genero = await generoService.GetById(Id);

            if (genero == null)
            {
                return NotFound();
            }

            return mapper.Map<GeneroDTO>(genero);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateGeneroDTO genero)
        {
            var generoCreateDTO = mapper.Map<Genero>(genero);
            await generoService.Insert(generoCreateDTO);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CreateGeneroDTO genero)
        {
            var generoUpdate = await generoService.GetById(id);

            if (generoUpdate == null)
            {
                return NotFound();
            }

            await generoService.Update(mapper.Map(genero, generoUpdate));

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var generoUpdate = await generoService.GetById(id);

            if (generoUpdate == null)
            {
                return NotFound();
            }

            await generoService.Delete(id);
            return NoContent();
        }

    }
}
