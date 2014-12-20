using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Catering.Data.Repositories.Common;
using Catering.Data.Repositories.Dish;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DishRepository), "AutoMapperStart")]
namespace Catering.Data.Repositories.Dish
{
    public class DishRepository:GenericRepository<Models.Dish>,IDishRepository
    {
        public DishRepository(DbContext context) : base(context)
        {
        }

        public async Task<Models.Dish> GetByIdAsync(int id)
        {
            return await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> GenerateIdAsync()
        {
            var max=await _dbSet.MaxAsync(el => (int?) el.Id) ?? 0;
            return 1 + max;
        }

        public async Task<bool> ExistsAsync(Expression<Func<Models.Dish, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<List<DishDTO>> GetDisplayDataAsync()
        {
            //return await _dbSet.Select(dish=>new DishDTO
            //{
            //    Id = dish.Id,
            //    Name = dish.Name
            //}).ToListAsync();
            var userlist = await _dbSet.ToListAsync();
            var list = Mapper.Map<List<DishDTO>>(userlist);
            return list;
        }

        public static void AutoMapperStart()
        {
            Mapper.CreateMap<Models.Dish, DishDTO>();
        }
    }
}
