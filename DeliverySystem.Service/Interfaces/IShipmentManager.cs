using DeliverySystem.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Service.Interfaces
{
    public interface IShipmentManager
    {
        List<ShipmentAllDTO> GetAll();
        List<ShipmentDTO> GetByAddressAndCategoryId(string address, int categoryId);
    }
}
