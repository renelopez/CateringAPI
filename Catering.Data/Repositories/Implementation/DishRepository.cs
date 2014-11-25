using System.Data.Entity;
using Catering.Data.DataLayer;
using Catering.Data.Models;

namespace Catering.Data.Repositories.Implementation
{
    public class DishRepository:GenericRepository<Dish>
    {
        public DishRepository(DbContext context) : base(context)
        {
        }
    }
}
