using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DeliverySystem.Service.DTOs
{
    public class ShipmentDTO
    {
        public List<ShipmentOrderDTO> Orders { get; set; }
    }
}
