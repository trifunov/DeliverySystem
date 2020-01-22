using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Service.DTOs
{
    public class ShipmentProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
        public string Total { get; set; }
        public string CategoryName { get; set; }
    }
}
