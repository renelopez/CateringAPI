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
using Catering.Data.Models;
using Catering.Data.Repositories.Common;
using Catering.Data.Repositories.Dish;
using Catering.Data.Repositories.Menu;
using Catering.Service.Controllers;

namespace Catering.Service.Controllers
{
    public class MenuController : ApiController
    {
        public IMenuRepository MenuRepository { get; set; }
        public IDishRepository DishRepository { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
        public MenuController(IMenuRepository orderRepository,IDishRepository dishRepository, IUnitOfWork unitOfWork)
        {
            this.MenuRepository = orderRepository;
            this.DishRepository = dishRepository;
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
        [ResponseType(typeof(MenuDTO))]
        public async Task<IHttpActionResult> PostMenu(MenuDTO menuDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dishes = menuDTO.Dishes.Select(dish => DishRepository.GetByIdAsync(dish.Id).Result).ToList();

            var model = MenuRepository.GetMenuFromDTO(menuDTO, dishes);

            MenuRepository.Add(model);
            //await UnitOfWork.CommitAsync();

            return CreatedAtRoute("DefaultApi", new { id = menuDTO.Id }, menuDTO);
        }

    }
}