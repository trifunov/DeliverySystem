using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliverySystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySystem.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderManager _orderManager;
        private readonly IProductManager _productManager;

        public OrderController(IOrderManager orderManager, IProductManager productManager)
        {
            _orderManager = orderManager;
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            var orders = _orderManager.GetAll();
            return View(orders);
        }
        public IActionResult GetProductsByOrderId(int orderId)
        {
            return Ok(_productManager.GetByOrderId(orderId));
        }

    }
}