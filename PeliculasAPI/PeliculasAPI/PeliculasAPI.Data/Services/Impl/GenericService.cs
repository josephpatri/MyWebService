using PeliculasAPI.DistributedServices.Services.Inter;
using PeliculasAPI.Domain.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.DistributedServices.Services.Impl
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {

        private IGenericRepository<TEntity> genericRepo;

        public GenericService(IGenericRepository<TEntity> _genericRepo)
        {
            this.genericRepo = _genericRepo;
        }

        public async Task Delete(int id)
        {
            await genericRepo.Delete(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await genericRepo.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await genericRepo.GetById(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            return await genericRepo.Insert(entity);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await genericRepo.Update(entity);
        }
    }
}
