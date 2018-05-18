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

            if (searchCriteria == null || searchCriteria == "Name")
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

            return View(model);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(string nameIn, string cityIn, string phoneNumberIn) //FormCollection collection
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

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

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
