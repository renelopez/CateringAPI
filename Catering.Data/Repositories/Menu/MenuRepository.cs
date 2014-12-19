using System.Data.Entity;
using AutoMapper;
using Catering.Data.Repositories.Common;
using Catering.Data.Repositories.Dish;
using Catering.Data.Repositories.Menu;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MenuRepository), "AutoMapperStart")]
namespace Catering.Data.Repositories.Menu
{

    public class MenuRepository : GenericRepository<Models.Menu>, IMenuRepository
    {
        public MenuRepository(DbContext context)
            : base(context)
        {
        }


        public static void AutoMapperStart()
        {
            Mapper.CreateMap<Models.User, MenuDTO>();
        }
    }
}
