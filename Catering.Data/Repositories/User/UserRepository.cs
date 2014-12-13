using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Catering.Data.Repositories.Common;
using Catering.Data.Repositories.User;

[assembly:WebActivatorEx.PreApplicationStartMethod(typeof(UserRepository),"AutoMapperStart")]
namespace Catering.Data.Repositories.User
{
    public class UserRepository:GenericRepository<Models.User>,IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public async Task<Models.User> GetById(int id)
        {
            return await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> GenerateIdAsync()
        {
            var max = await _dbSet.MaxAsync(el => (int?)el.Id) ?? 0;
            return 1 + max;
        }

        public async Task<bool> ExistsAsync(Expression<Func<Models.User, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<List<UserDTO>> GetDisplayDataAsync()
        {
            //return await _dbSet.Select(dish => new UserDTO
            //{
            //    Id = dish.Id,
            //    FirstName = dish.FirstName,
            //    LastName = dish.LastName,
            //    Username = dish.Username
            //}).ToListAsync();
            var userlist = await  _dbSet.ToListAsync();
            var  list= Mapper.Map<List<UserDTO>>(userlist);
            return list;
        }

        public static void AutoMapperStart()
        {
            Mapper.CreateMap<Models.User, UserDTO>();
        }
    }
}
