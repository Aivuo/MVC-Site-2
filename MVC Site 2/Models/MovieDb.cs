using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Site_2.Models
{
    public class MovieDb : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        //public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}