using System.Data.Entity;
using Catering.Data.Repositories.Common;

namespace Catering.Data.Repositories.Order
{
    public class OrderRepository:GenericRepository<Models.Order>,IOrderRepository
    {
        public OrderRepository(DbContext context)
            : base(context)
        {
        }
    }
}
