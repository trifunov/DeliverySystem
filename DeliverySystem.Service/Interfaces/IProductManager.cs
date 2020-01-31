using DeliverySystem.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Service.Interfaces
{
    public interface IProductManager
    {
        List<ProductDTO> GetByOrderId(int orderId);
    }
}
