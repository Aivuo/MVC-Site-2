using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Site_2.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string ShippingAddress { get; set; }
    }
}