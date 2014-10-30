using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Catering.Data.DataLayer;

namespace Catering.Service.Controllers
{
    public class LoginController : ApiController
    {
        public IUserRepository UserRepository { get; set; } 

        public LoginController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
    }
}
