using DeliverySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Data.Interfaces
{
    public interface IShipmentRepository
    {
        List<SPShipmentsGetAll> GetAll();
        List<SPShipmentsGetByAddressAndCategoryId> GetByAddressAndCategoryId(string address, int categoryId);
    }
}
