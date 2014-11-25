using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Catering.Data.Models;
using Catering.Data.Repositories.Contracts;

namespace Catering.Data.Repositories.Implementation
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public async Task<User> GetById(int id)
        {
            return await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
