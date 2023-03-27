using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class Restaurant
    {
        public string RestaurantId { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }
        public string JoinDate { get; set; }
    }
}