using PeliculasAPI.DistributedServices.Services.Inter;
using PeliculasAPI.Domain.Entidades;
using PeliculasAPI.Domain.Repos.Impl;
using PeliculasAPI.Domain.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.DistributedServices.Services.Impl
{
    public class ActorService : GenericService<Actor>, IActorService
    {
        private readonly IActorRepository repository;
        public ActorService(IActorRepository _repository) : base(_repository)
        {
            repository = _repository;
        }
    }
}
