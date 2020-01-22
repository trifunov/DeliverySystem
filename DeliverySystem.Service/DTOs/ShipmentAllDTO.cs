using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DeliverySystem.Service.DTOs
{
    public class ShipmentAllDTO
    {
		public string Address { get; set; }
		[DisplayName("Total Products to be shipped")]
		public int TotalProductsToBeShipped { get; set; }
		public int CategoryId { get; set; }

		[DisplayName("Category Name")]
		public string CategoryName { get; set; }
	}
}
