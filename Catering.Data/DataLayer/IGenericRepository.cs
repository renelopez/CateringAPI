using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.DataLayer
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> GetAll();
        Task<List<T>> FindBy(Expression<Func<T,bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        Task Save();
    }
}
