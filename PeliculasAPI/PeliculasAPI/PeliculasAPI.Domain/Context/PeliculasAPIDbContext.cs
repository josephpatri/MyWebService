using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Domain.Entidades;
using System;

namespace PeliculasAPI.Domain
{
    public class PeliculasAPIDbContext : DbContext
    {
        public PeliculasAPIDbContext(DbContextOptions options) : base(options)
        {
              
        }

        public DbSet<Genero> Generos { get; set; }
    }
}
