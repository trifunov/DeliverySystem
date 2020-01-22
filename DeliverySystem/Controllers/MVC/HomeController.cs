using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliverySystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySystem.Presentation.Controllers.MVC
{
    public class HomeController : Controller
    {
        private readonly IShipmentManager _shipmentManager;

        public HomeController(IShipmentManager shipmentManager)
        {
            _shipmentManager = shipmentManager;
        }

        public IActionResult Index()
        {
            var shipments = _shipmentManager.GetAll();
            return View(shipments);
        }
    }
}