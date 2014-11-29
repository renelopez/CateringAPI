using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Catering.Data.Models;

namespace Catering.Data.Repositories.Contracts
{
    public interface IDishRepository:IGenericRepository<Dish>
    {
        Task<int> GenerateIdAsync();
        Task<bool> ExistsAsync(Expression<Func<Dish, bool>> predicate);
    }
}
