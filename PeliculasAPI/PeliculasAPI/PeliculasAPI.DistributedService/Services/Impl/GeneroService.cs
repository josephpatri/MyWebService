using PeliculasAPI.DistributedServices.Services.Inter;
using PeliculasAPI.Domain.Entidades;
using PeliculasAPI.Domain.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.DistributedServices.Services.Impl
{
    public class GeneroService : GenericService<Genero>, IGeneroService
    {
        private readonly IGeneroRepository generoRepository;
        public GeneroService(IGeneroRepository _generoRepository) : base(_generoRepository)
        {
            this.generoRepository = _generoRepository;
        }
       
    }
}
