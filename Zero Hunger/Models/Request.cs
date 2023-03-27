using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class Request
    {
        public string RequestId { get; set; }
        public string FoodName { get; set; }
        public string FoodType { get; set; }
        public int Quantity { get; set; }

        public string Status { get; set; }
        public string Address { get; set; }
        public string AssignedEmployee { get; set; }
        public string RestaurantId { get; set; }
    }
}