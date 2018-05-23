using MVC_Site_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Site_2.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index(string searchTerm = null, string searchCriteria = null, string alpha = null)
        {
            IEnumerable<Person> model;

            if (searchTerm == null && searchCriteria == null && alpha == null)
            {
                model = _persons
                        .OrderBy(p => p.Id);
            }
            else if (searchCriteria == "Name")
            {
                if (alpha == null || alpha == "Descending")
                {
                    model = _persons
                    .OrderByDescending(p => p.Name)
                    .Where(p => searchTerm == null || p.Name.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase));
                }
                else
                {
                    model = _persons
                            .OrderBy(p => p.Name)
                            .Where(p => searchTerm == null || p.Name.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase));
                }
            }
            else
            {
                if (alpha == null || alpha == "Descending")
                {
                    model = _persons
                            .OrderByDescending(p => p.City)
                            .Where(p => searchTerm == null || p.City.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase));
                }
                else
                {
                    model = _persons
                           .OrderBy(p => p.City)
                           .Where(p => searchTerm == null || p.City.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase));
                }
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Person", model);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int idIn)
        {
            var person = _persons.Find(p => p.Id == idIn);

            return PartialView("_Edit", person);
        }

        [HttpPost]
        public ActionResult Edit(string nameIn, string phoneNumberIn, string cityIn, int idIn)
        {
            var person = _persons.Find(p => p.Id == idIn);

            person.Name = nameIn;
            person.City = cityIn;
            person.PhoneNumber = phoneNumberIn;

            return RedirectToAction("Index");
        }
        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(string nameIn, string cityIn, string phoneNumberIn)
        {
            try
            {
                var p = _persons.Last();


                _persons.Add(new Person
                {
                    Id = p.Id + 1,
                    Name = nameIn,
                    City = cityIn,
                    PhoneNumber = phoneNumberIn
                });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int idIn)
        {
            var person = _persons.Find(p => p.Id == idIn);
            _persons.Remove(person);

            return RedirectToAction("Index");
        }
        //Detta ligger bara här för att tittas på. Försökte lösa samma sak på olika sätt.
        //public PartialViewResult PlayerList(int id)
        //{
        //    sätt 1
        //    var result = PartialView("_Person", _persons.Find(p => p.Id == id));

        //    return PartialView(result);

        //    sätt 2
        //    List<PartialViewResult> result = new List<PartialViewResult>();
        //    //PartialViewResult result = new;
        //    foreach (var item in _persons)
        //    {

        //        result.Add(PartialView("_Person", item));
        //    }

        //    sätt 3
        //    var result = _persons.Find(p => p.Id == id);
        //}



        static List<Person> _persons = new List<Person>
        {
            new Person
            {
                Id = 1,
                Name = "Who",
                City = "Chicago",
                PhoneNumber = "0000 57 98 76"
            },
            new Person
            {
                Id = 2,
                Name = "What",
                City = "New York",
                PhoneNumber = "0000 57 98 76"
            },
             new Person
            {
                Id = 3,
                Name = "I don't know",
                City = "Miami",
                PhoneNumber = "0000 57 98 76"
            },
            new Person
            {
                Id = 4,
                Name = "Why",
                City = "Denver",
                PhoneNumber = "0000 57 98 76"
            },
            new Person
            {
                Id = 5,
                Name = "Because",
                City = "Washington D.C",
                PhoneNumber = "0000 57 98 76"
            },
            new Person
            {
                Id = 6,
                Name = "Today",
                City = "Austin",
                PhoneNumber = "0000 57 98 76"
            },
            new Person
            {
                Id = 7,
                Name = "Tomorrow",
                City = "Maryland",
                PhoneNumber = "0000 57 98 76"
            },
            new Person
            {
                Id = 8,
                Name = "I don't give a darn",
                City = "Dallas",
                PhoneNumber = "0000 57 98 76"
            },
        };
    }
}
