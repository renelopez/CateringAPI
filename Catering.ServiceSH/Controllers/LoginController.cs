using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Catering.Data.DataLayer;

namespace Catering.ServiceSH.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        public IUserRepository UserRepository { get; set; } 

        public LoginController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        [Route("")]
        [HttpPost]
        public async Task<LoginModel> Login([FromBody]LoginCredentials credentials)
        {
            var user = await UserRepository.FindBy(usr => usr.UserName == credentials.Username && usr.Password == credentials.Password);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return new LoginModel()
            {
                IsValid = true,
                UserType = (int) user.FirstOrDefault().Type
            };
        }
    }

    public class LoginModel
    {
        public bool IsValid { get; set; }
        public int UserType { get; set; }
    }
}
