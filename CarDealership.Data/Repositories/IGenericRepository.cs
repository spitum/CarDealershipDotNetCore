using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        TEntity GetById(object id);

        Task DeleteAsync(TEntity entity);
    }
}
