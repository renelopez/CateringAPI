using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catering.Data.Models;

namespace Catering.Data.DataLayer
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public Task<User> GetById(int id)
        {
            return _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
