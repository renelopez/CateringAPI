using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Catering.Data.Repositories.Contracts
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> FindBy(Expression<Func<T, bool>> predicate);
        Task<T> FindOneBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        Task Save();
    }
}
