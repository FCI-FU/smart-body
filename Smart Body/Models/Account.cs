using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart__Body.Models
{
    public class Account
    {
        public string Name { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string contactNo { get; set; }
        public bool hasGym { get; set; }
        public string gymName { get; set; }
        public string gymLocation { get; set; }
        public string gymPhone { get; set; }
    }
}