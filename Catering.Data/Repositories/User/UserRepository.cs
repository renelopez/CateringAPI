using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Catering.Data.Repositories.Common;

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
    }
}
