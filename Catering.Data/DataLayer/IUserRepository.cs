using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catering.Data.Models;

namespace Catering.Data.DataLayer
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User> GetById(int id);
    }
}
