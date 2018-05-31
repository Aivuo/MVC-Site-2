using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Site_2.Models
{
    public class Order
    {
        public List<Movie> OrderItems { get; set; }
    }
}