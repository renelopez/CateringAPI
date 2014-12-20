using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catering.Data.Repositories.Common;
using Catering.Data.Repositories.Dish;

namespace Catering.Data.Repositories.Menu
{
    public interface IMenuRepository:IGenericRepository<Models.Menu>
    {
        Models.Menu GetMenuFromDTO(MenuDTO menuDto, List<Models.Dish> dishes);
    }
}
