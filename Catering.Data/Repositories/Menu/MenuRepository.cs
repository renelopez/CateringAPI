using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catering.Data.Models;
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

        public Models.Menu GetMenuFromDTO(MenuDTO menuDto,List<Models.Dish> dishes)
        {
            var menu = new Models.Menu()
            {
                DateTime = Convert.ToDateTime(menuDto.FormattedDate),
                MenuDishes = menuDto.Dishes.Select(dish => new MenuDish()
                {
                    DateTime = Convert.ToDateTime(dish.FormattedDate),
                    Dish = dishes.FirstOrDefault(d => d.Id == dish.Id),

                }).ToList()

            };
            return menu;
        }

       

        public static void AutoMapperStart()
        {
            //Mapper.CreateMap<string,DateTime>().ConvertUsing(Convert.ToDateTime);
            //Mapper.CreateMap<Models.Menu, MenuDTO>()
            //    .ForMember(menuDto => menuDto.FormattedDate, m => m.MapFrom(menu => menu.DateTime));
            //Mapper.CreateMap<Models.MenuDish, DishDTO>()
            //    .ForMember(dish => dish, m => m.MapFrom(menudish => menudish.Dish));
            //.ForMember(menuDto => menuDto.Dishes.Select(e => e.Name),
            //    m => m.MapFrom(menu => menu.MenuDishes.Select(e => e.Dish.Name)))
            //.ForMember(menuDto => menuDto.Dishes.Select(e => e.FormattedDate),
            //    m => m.MapFrom(menu => menu.MenuDishes.Select(e => e.DateTime)));
        }
    }
}
