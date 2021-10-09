using PeliculasAPI.Context.Domain;
using PeliculasAPI.Domain.Entidades;
using PeliculasAPI.Domain.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.Domain.Repos.Impl
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(PeliculasAPIDbContext context) : base(context)
        {

        }
    }
}
