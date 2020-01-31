using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DeliverySystem.Service.DTOs
{
    public class ProductDTO
    {
        [DisplayName("Product name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("SKU")]
        public string Sku { get; set; }
        [DisplayName("Category name")]
        public string CategoryName { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public string Total { get; set; }
    }
}
