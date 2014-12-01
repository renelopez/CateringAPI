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
using Catering.Data.Repositories.Order;

namespace Catering.Service.Controllers
{
    public class OrderController : ApiController
    {
        public IOrderRepository OrderRepository { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
        public OrderController(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            this.OrderRepository = orderRepository;
            this.UnitOfWork = unitOfWork;
        }

      
        // POST: api/Orders
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OrderRepository.Add(order);
            await UnitOfWork.CommitAsync();

            return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
        }

        
    }
}