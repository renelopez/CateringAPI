using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Catering.Data.DataLayer;
using Catering.Data.Models;
using Catering.Data.Repositories.User;

namespace Catering.Service.Controllers
{
    public class UserController : ApiController
    {
         public IUserRepository UserRepository { get; set; } 

        public UserController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        [HttpGet]
        public async Task<List<User>> GetAll()
        {
            return await UserRepository.GetAllAsync();
        } 
    }
}
