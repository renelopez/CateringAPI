using System.Data.Entity;
using Catering.Data.DataLayer;
using Catering.Data.Models;
using Catering.Data.Repositories.Contracts;

namespace Catering.Data.Repositories.Implementation
{
    public class OrderRepository:GenericRepository<Order>,IOrderRepository
    {
        public OrderRepository(DbContext context)
            : base(context)
        {
        }
    }
}
