using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliverySystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySystem.Web.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly IShipmentManager _shipmentManager;

        public ShipmentController(IShipmentManager shipmentManager)
        {
            _shipmentManager = shipmentManager;
        }

        public IActionResult Index()
        {
            var shipments = _shipmentManager.GetAll();
            return View(shipments);
        }

        public IActionResult GetByAddressAndCategoryId(string address, int categoryId)
        {
            return Ok(_shipmentManager.GetByAddressAndCategoryId(address, categoryId));
        }
    }
}