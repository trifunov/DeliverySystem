using System;
using System.Collections.Generic;

namespace DeliverySystem.Data.Models
{
    public partial class TestOrderProducts
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get; set; }
    }
}
