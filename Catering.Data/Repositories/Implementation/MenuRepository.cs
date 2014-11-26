using System.Data.Entity;
using Catering.Data.DataLayer;
using Catering.Data.Models;
using Catering.Data.Repositories.Contracts;

namespace Catering.Data.Repositories.Implementation
{
    public class MenuRepository:GenericRepository<Menu>,IMenuRepository
    {
        public MenuRepository(DbContext context)
            : base(context)
        {
        }
    }
}
