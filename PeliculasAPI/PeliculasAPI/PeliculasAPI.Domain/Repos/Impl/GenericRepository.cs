using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PeliculasAPI.Context.Domain;
using PeliculasAPI.Domain.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.Domain.Repos.Interfaces
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly PeliculasAPIDbContext PeliculasAPIDbContext;        

        public GenericRepository(PeliculasAPIDbContext _PeliculasAPIDbContext)
        {
            PeliculasAPIDbContext = _PeliculasAPIDbContext;            
        }

        public IQueryable<TEntity> BuildQuery()
        {
            return PeliculasAPIDbContext.Set<TEntity>().AsQueryable();
        }

        public int Count()
        {
            return PeliculasAPIDbContext.Set<TEntity>().ToList().Count();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entity is null");

            PeliculasAPIDbContext.Set<TEntity>().Remove(entity);
            await PeliculasAPIDbContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await PeliculasAPIDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await PeliculasAPIDbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            await PeliculasAPIDbContext.Set<TEntity>().AddAsync(entity);
            await PeliculasAPIDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            PeliculasAPIDbContext.Set<TEntity>().Update(entity);
            await PeliculasAPIDbContext.SaveChangesAsync();
            return entity;
        }
    }
}