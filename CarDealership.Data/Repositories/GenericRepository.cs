using CarDealership.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        protected readonly AppDBContext _context;
        private DbSet<TEntity> table = null;

        public GenericRepository(AppDBContext context)
        {
            _context = context;
            table = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(DeleteAsync)} entity must not be null");
            }
            try
            {
                table.Remove(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be deleted: {ex.Message}");
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return table;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public TEntity GetById(object id)
        {
            return  table.Find(id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {

                table.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
    }
}