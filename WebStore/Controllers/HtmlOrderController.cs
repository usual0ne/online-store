using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Entities;
using Infrastructure.DataAccess;

namespace WebStore.Controllers
{
    [Route("html/[controller]")]
    public class HtmlOrderController : Controller
    {
        private IOrderRepository _orderRepository { get; set; }

        public HtmlOrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_orderRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            return View(_orderRepository.Get(id));
        }

        [HttpGet("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Order order)
        {
            try
            {
                _orderRepository.Add(order);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("update/{id}")]
        public ActionResult Edit(int id)
        {
            return View(_orderRepository.Get(id));
        }

        [HttpPost("update/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] Order order)
        {
            try
            {
                _orderRepository.Update(order);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
