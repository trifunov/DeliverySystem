using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Service.DTOs
{
    public class ShipmentOrderDTO
    {
        public int OrderId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
        public string Total { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
