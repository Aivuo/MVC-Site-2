﻿using MVC_Site_2.Models;
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
        public ActionResult FeverCheck(float temperature = 37, string scale = "celsius")
        {
            string haveFever = Checks.HaveFeverCheck(scale, temperature);

            ViewBag.haveFever = haveFever;

            ViewBag.Message = "FeverStuff with temperature";
            return View();
        }

        [HttpGet]
        public ActionResult GuessingGame()
        {
            var rnd = new Random();
            int guessThisNumber = rnd.Next(1, 100);
            int numberOfGuesses = 0;

            //var guessCorrect = false;

            Session["guessThisNumber"] = guessThisNumber;
            Session["guessCorrect"] = "false";
            Session["isItCorrect"] = null;
            Session["numberOfGuesses"] = numberOfGuesses;
            return View();
        }

        [HttpPost]
        public ActionResult GuessingGame(int guess = 0, string guessCorrect = "false", int numberOfGuesses = 0)
        {

            string isItCorrect = null;

            if (guessCorrect == "true")
            {
                return RedirectToAction("GuessingGame", new { });
            }

            guessCorrect = "false";
            int guessThisNumber = (int)(Session["guessThisNumber"]);


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

            numberOfGuesses++;

            Session["numberOfGuesses"] = numberOfGuesses;
            Session["guessCorrect"] = guessCorrect;
            Session["isItCorrect"] = isItCorrect;
            return View();
        }
    }
}