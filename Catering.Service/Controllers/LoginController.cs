using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Catering.Data.DataLayer;

namespace Catering.Service.Controllers
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
        [ResponseType(typeof(LoginModel))]
        public async Task<IHttpActionResult> Login([FromBody]LoginCredentials credentials)
        {
            var user = await UserRepository.FindBy(usr => usr.UserName == credentials.Username && usr.Password == credentials.Password);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(new LoginModel()
            {
                IsValid = true,
                UserType = (int) user.FirstOrDefault().Type
            });
        }
    }

    public class LoginModel
    {
        public bool IsValid { get; set; }
        public int UserType { get; set; }
    }
}
