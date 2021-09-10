using PeliculasAPI.Domain.Entidades;
using PeliculasAPI.Domain.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.Domain.Repos.Impl.GeneroRepository
{
    public class GeneroRepository : GenericRepository<Genero>, IGeneroRepository
    {
        public GeneroRepository(PeliculasAPIDbContext context) : base(context)
        {

        }
    }
}
