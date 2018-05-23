using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Site_2.Models
{
    public class Person
    {

        //Har pillat med Requirements och de är styrkta men de visas inte för användaren om de inte uppfylls.
        //De läggs bara inte in i "databasen"
        public int Id { get; set; }

        [Required(ErrorMessage = "You need to enter a name")]
        [StringLength(50, ErrorMessage = "The full name must be less than {1} characters")]
        [Display(Name = "Full name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You need to enter a Homecity")]
        [StringLength(50, ErrorMessage = "The city must be less than {1} characters")]
        [Display(Name = "Homecity")]
        public string City { get; set; }

        [Required(ErrorMessage = "You need to enter a Phonenumber")]
        [StringLength(50, ErrorMessage = "The number must be less than {1} characters")]
        [Display(Name = "0000 12 34 56")]
        public string PhoneNumber { get; set; }
    }
}