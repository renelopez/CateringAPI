using System.Web.Http;
using Catering.Data.DataLayer;

namespace Catering.ServiceSH.Controllers
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
