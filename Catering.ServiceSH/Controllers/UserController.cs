using System.Collections.Generic;
using System.Web.Http;
using Catering.Data.DataLayer;
using Catering.Data.Models;

namespace Catering.ServiceSH.Controllers
{
    public class UserController : ApiController
    {
         public IUserRepository UserRepository { get; set; } 

        public UserController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return UserRepository.GetAll();
        } 
    }
}
