using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DeliverySystem.Service.DTOs
{
    public class ShipmentDTO
    {
        public int OrderId { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ShipmentProductDTO> Products { get; set; }
    }
}
