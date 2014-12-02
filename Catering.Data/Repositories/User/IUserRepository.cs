using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Catering.Data.Repositories.Common;

namespace Catering.Data.Repositories.User
{
    public interface IUserRepository:IGenericRepository<Models.User>
    {
        Task<int> GenerateIdAsync();
        Task<bool> ExistsAsync(Expression<Func<Models.User, bool>> predicate);
        Task<List<UserDTO>> GetDisplayDataAsync();
    }
}
