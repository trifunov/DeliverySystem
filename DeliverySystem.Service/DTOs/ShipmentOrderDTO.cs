using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Service.DTOs
{
    public class ShipmentOrderDTO
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
