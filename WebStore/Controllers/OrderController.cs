using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Entities;
using Infrastructure.DataAccess;

namespace WebStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository _orderRepository { get; set; }

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _orderRepository.GetAll();
        }


        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _orderRepository.Get(id);
        }


        [HttpPost]
        public ActionResult Post([FromBody] Order order)
        {
            _orderRepository.Add(order);
            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Order order)
        {
            _orderRepository.Update(order);
            return Ok();
        }

    }
}
