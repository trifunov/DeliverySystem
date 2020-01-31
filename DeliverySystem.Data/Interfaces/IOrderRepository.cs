using DeliverySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Data.Interfaces
{
    public interface IOrderRepository
    {
        List<Tuple<int, string, string, string, string, string, string, Tuple<int>>> GetAll();
    }
}
