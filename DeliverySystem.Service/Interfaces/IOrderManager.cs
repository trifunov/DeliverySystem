using DeliverySystem.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Service.Interfaces
{
    public interface IOrderManager
    {
        List<OrderDTO> GetAll();
    }
}
