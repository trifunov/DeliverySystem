using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Data.Models
{
    public class SPShipmentsGetAll
    {
        public string Address { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int TotalProductsToBeShipped { get; set; }
    }
}
