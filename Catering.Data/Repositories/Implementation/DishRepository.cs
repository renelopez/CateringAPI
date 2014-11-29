using System;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Catering.Data.DataLayer;
using Catering.Data.Models;
using Catering.Data.Repositories.Contracts;

namespace Catering.Data.Repositories.Implementation
{
    public class DishRepository:GenericRepository<Dish>,IDishRepository
    {
        public DishRepository(DbContext context) : base(context)
        {
        }

        public async Task<int> GenerateIdAsync()
        {
            var max=await _dbSet.MaxAsync(el => (int?) el.Id) ?? 0;
            return 1 + max;
        }

        public async Task<bool> ExistsAsync(Expression<Func<Dish, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
    }
}
