using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Catering.Data.Models;
using Catering.Data.Repositories.Common;
using Catering.Data.Repositories.Dish;
using Catering.Service.Controllers;

//[assembly :WebActivatorEx.PreApplicationStartMethod(typeof(DishController),"AutoMapperStart")]
namespace Catering.Service.Controllers
{
    [RoutePrefix("api/dish")]
    public class DishController : ApiController
    {
        public IDishRepository DishRepository { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        public DishController(IDishRepository dishRepository,IUnitOfWork unitOfWork)
        {
            DishRepository = dishRepository;
            UnitOfWork = unitOfWork;
        }

        // GET api/<controller>
        [Route("")]
        [ResponseType(typeof(DishListDTO))]
        public async Task<DishListDTO> Get()
        {
            var dishes =await DishRepository.GetDisplayDataAsync();
            return new DishListDTO {dishList = dishes};
        }

        // GET api/<controller>/5
        [Route("{id:int}",Name="GetDishById")]
        [ResponseType(typeof(Dish))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var dish = await DishRepository.FindOneByAsync(elem => elem.Id == id);
            if (dish == null)
            {
                return NotFound();
            }
            return Ok(dish);
        }

        // POST api/<controller>
        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]Dish dish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await DishRepository.ExistsAsync(elem => elem.Name == dish.Name))
            {
                return BadRequest("The dish name already exists.Please type another one.");
            }
            dish.Id = await DishRepository.GenerateIdAsync();
            DishRepository.Add(dish);
            await UnitOfWork.CommitAsync();
            return CreatedAtRoute("GetDishById", new { id = dish.Id }, dish);
        }

        // DELETE api/<controller>/5
        [Route("{id:int}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var dish = await DishRepository.FindOneByAsync(elem => elem.Id == id);
            if (dish == null)
            {
                return NotFound();
            }
            DishRepository.Delete(dish);
            await UnitOfWork.CommitAsync();
            return Ok(dish);
        }
    }
}