using System.Data.Entity;
using Catering.Data.Repositories.Common;

namespace Catering.Data.Repositories.Menu
{
    public class MenuRepository : GenericRepository<Models.Menu>, IMenuRepository
    {
        public MenuRepository(DbContext context)
            : base(context)
        {
        }
    }
}
