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
        public List<ShipmentProductDTO> Products { get; set; }
    }
}
