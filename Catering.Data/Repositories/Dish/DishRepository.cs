using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Catering.Data.Repositories.Common;

namespace Catering.Data.Repositories.Dish
{
    public class DishRepository:GenericRepository<Models.Dish>,IDishRepository
    {
        public DishRepository(DbContext context) : base(context)
        {
        }

        public async Task<int> GenerateIdAsync()
        {
            var max=await _dbSet.MaxAsync(el => (int?) el.Id) ?? 0;
            return 1 + max;
        }

        public async Task<bool> ExistsAsync(Expression<Func<Models.Dish, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<List<DishDTO>> GetDishListAsync()
        {
            return await _dbSet.Select(dish =>new DishDTO{Id=dish.Id,Name=dish.Name}).ToListAsync();
        }
    }
}
