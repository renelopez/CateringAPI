using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Catering.Data.Repositories.Common;

namespace Catering.Data.Repositories.Dish
{
    public interface IDishRepository:IGenericRepository<Models.Dish>
    {
        Task<int> GenerateIdAsync();
        Task<bool> ExistsAsync(Expression<Func<Models.Dish, bool>> predicate);

        Task<List<DishDTO>> GetDisplayDataAsync();
    }
}
