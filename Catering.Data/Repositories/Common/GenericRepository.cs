using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Catering.Data.Repositories.Common
{
    public abstract class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        protected DbContext _entities;
        protected readonly IDbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbSet = context.Set<T>();
        }
        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<T> FindOneByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public T Add(T entity)
        {
            return _dbSet.Add(entity);
        }

        public T Delete(T entity)
        {
            return _dbSet.Remove(entity);
        }

        public void Edit(T entity)
        {
            _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public async Task Save()
        {
            await _entities.SaveChangesAsync();
        }
    }
}
