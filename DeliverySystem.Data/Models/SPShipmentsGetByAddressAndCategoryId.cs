﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Data.Models
{
    public class SPShipmentsGetByAddressAndCategoryId
    {
		public int OrderId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }
		public string ProductSKU { get; set; }
		public int OrderProductId { get; set; }
		public int ProductQuantity { get; set; }
		public decimal ProductPrice { get; set; }
		public decimal TotalProductPrice { get; set; }
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
	}
}
