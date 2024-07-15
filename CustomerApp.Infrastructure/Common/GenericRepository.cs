using CustomerApp.Core.Infrastructure;
using CustomerApp.Domain.Common;
using CustomerApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Infrastructure.Common
{
    public class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : Entity<TKey>
    {
        protected readonly CustomerDbContext _dbContext;

        public GenericRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(TKey id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbContext.Entry<T>(entity).State = EntityState.Modified;
            _dbContext.Set<T>().Update(entity);
        }
    }
}
