using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DeliverySystem.Service.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        [DisplayName("Total products")]
        public int TotalProducts { get; set; }
    }
}
