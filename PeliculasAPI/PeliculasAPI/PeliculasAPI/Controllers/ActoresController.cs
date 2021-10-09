using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PeliculasAPI.DistributedServices.Extensions;
using PeliculasAPI.DistributedServices.Services.Inter;
using PeliculasAPI.Domain.Entidades;
using PeliculasAPI.Domain.Entidades.DTO;
using PeliculasAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasAPI.Controllers
{
    [Route("api/actores")]
    [ApiController]
    [EnableCors()]
    public class ActoresController : Controller
    {
        private readonly ILogger<ActoresController> logger;
        private readonly IMapper mapper;
        private readonly IActorService service;
        private readonly ILocalFileManager fileManager;
        private readonly string container = "actores";

        public ActoresController(ILogger<ActoresController> _logger, IMapper _mapper
            , IActorService _service, ILocalFileManager fileManager)
        {
            service = _service;
            this.fileManager = fileManager;
            logger = _logger;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> Get([FromQuery] PaginationDTO pagination)
        {
            var query = service.BuidQuery();
            await HttpContext.InsertPaginationHeadersParams(query);
            var actors = await query.OrderBy(x => x.Nombre).Paginate(pagination).ToListAsync();
            return mapper.Map<List<ActorDTO>>(actors);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CreateActorDTO createActor)
        {
            var actor = mapper.Map<Actor>(createActor);
            if (createActor.Foto != null)
            {
                actor.Foto = await fileManager.FileSave(container, createActor.Foto);
            }
            await service.Insert(actor);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var actor = await service.GetById(id);

            if(actor == null)
            {
                return NotFound();
            }

            await service.Delete(id);
            await fileManager.DeleteFIle(actor.Foto, container);
            return NoContent();
        }
    }
}
