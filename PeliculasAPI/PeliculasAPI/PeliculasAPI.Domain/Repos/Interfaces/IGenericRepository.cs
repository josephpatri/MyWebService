using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.Domain.Repos.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        IQueryable<TEntity> BuildQuery();

        Task<TEntity> Insert(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task Delete(int id);
    }
}