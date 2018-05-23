using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Site_2.Models
{
    public class Search
    {
        public static IEnumerable<Person> SearchList(string searchTerm, string searchCriteria, string alpha, IEnumerable<Person> _persons)
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

            return model;
        }
    }
}