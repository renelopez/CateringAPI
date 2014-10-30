using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catering.Data.Models;

namespace Catering.Data.DataLayer
{
    public class DishRepository:GenericRepository<Dish>,IDishRepository
    {
        public DishRepository(DbContext context) : base(context)
        {
        }

        public Task<Dish> GetById(int id)
        {
            return _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
