using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Catering.Data.Models;
using Catering.Data.Repositories.Common;
using Catering.Data.Repositories.User;

namespace Catering.Service.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
         public IUserRepository UserRepository { get; set; }
         public IUnitOfWork UnitOfWork { get; set; }

        public UserController(IUserRepository userRepository,IUnitOfWork unitOfWork)
        {
            UserRepository = userRepository;
            UnitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(UserListDTO))]
        public async Task<UserListDTO> Get()
        {
            var userList= await UserRepository.GetDisplayDataAsync();
            return new UserListDTO{UserList = userList};
        }

        // GET api/<controller>/5
        [Route("{id:int}", Name = "GetById")]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var user = await UserRepository.FindOneByAsync(elem => elem.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<controller>
        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await UserRepository.ExistsAsync(elem => elem.UserName == user.UserName))
            {
                return BadRequest("The username already exists.Please type another one.");
            }
            user.Id = await UserRepository.GenerateIdAsync();
            UserRepository.Add(user);
            await UnitOfWork.CommitAsync();
            return CreatedAtRoute("GetById", new { id = user.Id },user);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var dish = await UserRepository.FindOneByAsync(elem => elem.Id == id);
            if (dish == null)
            {
                return NotFound();
            }
            UserRepository.Delete(dish);
            await UnitOfWork.CommitAsync();
            return Ok(dish);
        }
    }
}
