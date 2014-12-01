using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Catering.Data.Repositories.Common
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindOneByAsync(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        Task Save();
    }
}
