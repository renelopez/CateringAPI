using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Catering.Data.DataLayer;
using Catering.Data.Models;
using Catering.Data.Repositories.Common;
using Catering.Data.Repositories.Menu;

namespace Catering.Service.Controllers
{
    public class MenuController : ApiController
    {
        public IMenuRepository MenuRepository { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
        public MenuController(IMenuRepository orderRepository, IUnitOfWork unitOfWork)
        {
            this.MenuRepository = orderRepository;
            this.UnitOfWork = unitOfWork;
        }

        // GET: api/Menu/5
        [ResponseType(typeof(Menu))]
        public async Task<IHttpActionResult> GetMenu(int id)
        {
            Menu menu = await MenuRepository.FindOneByAsync(el => el.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }
        // POST: api/Menu
        [ResponseType(typeof(Menu))]
        public async Task<IHttpActionResult> PostMenu(Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MenuRepository.Add(menu);
            await UnitOfWork.CommitAsync();

            return CreatedAtRoute("DefaultApi", new { id = menu.Id }, menu);
        }
    }
}