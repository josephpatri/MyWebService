using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Domain.Entidades;
using System;

namespace PeliculasAPI.Context.Domain
{
    public class PeliculasAPIDbContext : DbContext
    {
        public PeliculasAPIDbContext(DbContextOptions options) : base(options)
        {
              
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
    }
}
