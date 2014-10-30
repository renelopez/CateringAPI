using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Catering.Data.DataLayer;
using Catering.Data.Models;

namespace Catering.Service.Controllers
{
    public class UserController : ApiController
    {
         public IUserRepository UserRepository { get; set; } 

        public UserController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return UserRepository.GetAll();
        } 
    }
}
