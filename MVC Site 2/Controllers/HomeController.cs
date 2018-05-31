using MVC_Site_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Site_2.Controllers
{
    public class HomeController : Controller
    {

        MovieDb _db = new MovieDb();
        // GET: Home
        public ActionResult Index()
        {
            var model = _db.Movies.ToList();
            ViewBag.Message = "You start here";

            return View(model);
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

        [HttpGet] //Kallar bara på sidan FeverCheck när användaren navigerar dit.
        public ActionResult FeverCheck()
        {
            ViewBag.Message = "FeverStuff";
            return View();
        }

        [HttpPost] //Kallar på en annan variant av sidan när spelaren skickar in information med sidan
        public ActionResult FeverCheck(float temperature = 37, string scale = "celsius")
        {
            //Kallar på modellen Checks och dess statiska metod HaveFeverCheck. Den ger tillbaka en string som har ett meddelande till användaren
            string haveFever = Checks.HaveFeverCheck(scale, temperature);

            //Sparar det som HaveFeverCheck återvänder. Skulle kunna göras på en rad men jag ser detta som tydligare.
            ViewBag.haveFever = haveFever;

            //Bara ett roligt meddelande xD
            ViewBag.Message = "FeverStuff with temperature";
            return View();
        }

        [HttpGet]
        public ActionResult GuessingGame()
        {

            //När användaren navigerar till sidan så skapar den ett nyt slump seed som den sen använder för att slumpa ett tal mellan 1-100.
            //Här initierar jag också antalet gissningar som spelaren har gjort. Det är för att ta upp den minnesaddressen i Session.
            var rnd = new Random();
            int guessThisNumber = rnd.Next(1, 100);
            int numberOfGuesses = 0;

            //Spara alla variabler till Session. guessCorrect och isItCorrect kan inte vara korrekta första gången och de krävs för 
            //att view ska fungera ordenligt.
            Session["guessThisNumber"] = guessThisNumber;
            Session["guessCorrect"] = "false";
            Session["isItCorrect"] = null;
            Session["numberOfGuesses"] = numberOfGuesses;
            return View();
        }

        [HttpPost]
        public ActionResult GuessingGame(int guess = 0, string guessCorrect = "false", int numberOfGuesses = 0)
        {
            //Sätter isItCorrect till null för att om den slumpar ett nytt nummer så ska inte Session skriva ut det i view
            string isItCorrect = null;

            //Om spelaren gissar rätt och trycker på play again så kallar den på Get Action och slumpar ett nytt nummer.
            if (guessCorrect == "true")
            {
                return RedirectToAction("GuessingGame", new { });
            }

            //Hämtar ut guessThisNumber ur Session
            int guessThisNumber = (int)(Session["guessThisNumber"]);

            //Kollar och skriver ut meddelandet till användaren. Ligger inte i en model då jag hade behövt göra en extra check för att
            //sätta guessCorrect till true
            if (guess > guessThisNumber + 10)
            {
                isItCorrect = "It's a bit too high.";
            }
            else if (guess > guessThisNumber)
            {
                isItCorrect = "It's a little bit too high.";
            }
            else if (guess < guessThisNumber - 10)
            {
                isItCorrect = "It's a bit too low.";
            }
            else if (guess < guessThisNumber)
            {
                isItCorrect = "It's a little bit too low.";
            }
            else
            {
                isItCorrect = "You are right on the money!";
                guessCorrect = "true";
            }

            //Ökar siffran för användarens antal gissningar
            numberOfGuesses++;

            //Sätter och skriver över variablerna i Session
            Session["numberOfGuesses"] = numberOfGuesses;
            Session["guessCorrect"] = guessCorrect;
            Session["isItCorrect"] = isItCorrect;
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}