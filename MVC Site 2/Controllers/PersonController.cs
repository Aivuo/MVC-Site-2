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
            //Sorterar listan som ska visas för användaren
            var model = Search.SearchList(searchTerm, searchCriteria, alpha, _persons);

            //Ser till att hela sidan inte uppdateras när en Ajax request skickas 
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Person", model);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            //Letar upp i "databasen" vilket element du vill ändra på och lämnar tillbaka en partial view för att ändra den.
            if (ModelState.IsValid)
            {
                var person = _persons.Find(p => p.Id == Id);

                return PartialView("_Edit", person); 
            }

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Person personIn)
        {
            //Kollar så att det faktiskt är en fungerande person som kommer in xD.
            if (ModelState.IsValid)
            {
                //Sätter den inkommande personens Id till ett högre än den sista i "databasen". Detta då personen som kommer in inte kommer att ha ett Id
                var person = _persons.Find(p => p.Id == personIn.Id);

                //Ändrar bara den utplockade spelarens properties
                person.Name = personIn.Name;
                person.City = personIn.City;
                person.PhoneNumber = personIn.PhoneNumber; 
            }

            return RedirectToAction("Index");
        }
        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Lägger till Id då användaren inte kan ge den inkommande person ett Id
                    var p = _persons.Last();
                    person.Id = p.Id + 1;
                    _persons.Add(person);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Id)
        {
            //Letar upp vilken spelare det är du vill ta bort och tar sedan bort den och uppdaterar listan
            var person = _persons.Find(p => p.Id == Id);
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


        //"Databasen"
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
