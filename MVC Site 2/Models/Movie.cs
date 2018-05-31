using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Site_2.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public int Rating { get; set; }
    }
}