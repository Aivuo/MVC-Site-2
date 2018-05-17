using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Site_2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = "You start here";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "There might be some stuff about stuff here";
            return View();
        }

        public ActionResult Projects()
        {
            ViewBag.Message = "Stuff gets put here";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact information";
            return View();
        }

        [HttpGet]
        public ActionResult FeverCheck()
        {
            ViewBag.Message = "FeverStuff";
            return View();
        }

        [HttpPost]
        public ActionResult FeverCheck(int temperature)
        {
            //bool fever = false;
            //bool hypothermia = false;
            string haveFever;

            if (temperature > 38)
            {
                haveFever = "Yes you have a fever.";
            } else if(temperature > 35)
            {
                haveFever = "No, you are perfectly fine.";
            }
            else if (temperature > 32)
            {
                haveFever = "No but you have a mild case of Hypothermia. Drink something warm and contact a doctor.";
            }
            else if (temperature > 28)
            {
                haveFever = "You have severe Hypothermia. Get to a doctor now!";
            } else
            {
                haveFever = "How did you even write this? You should be unconcious!";
            }

            ViewBag.haveFever = haveFever;

            ViewBag.Message = "FeverStuff with temperature";
            return View();
        }
    }
}