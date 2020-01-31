using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Data.Interfaces
{
    public interface IProductRepository
    {
        List<Tuple<string, string, string, string, decimal?, int?, decimal?>> GetByOrderId(int orderId);
    }
}
