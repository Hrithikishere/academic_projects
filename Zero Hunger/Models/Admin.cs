using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class Admin
    {
        public string AdminId { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }

        public string JoinDate { get; set; }
    }
}