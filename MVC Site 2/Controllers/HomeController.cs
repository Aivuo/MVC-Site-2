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
    }
}