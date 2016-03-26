using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoToParks.Core
{
    public class ParkRepository
    {
        public ParkRepository()
        {

        }

        public List<Park> GetAllParks()
        {
            return parks;
        }

        private static List<Park> parks = new List<Park>()
        {
            new Park()
            {
                Id = 1,
                Name = "Seward Park",
                Address = "5900 Lake Washington Blvd S",
                Lat = 47.54923m,
                Long = -122.250639m
            },
            new Park()
            {
                Id = 2,
                Name = "Discover Park",
                Address = "3801 Discover Park Blvd",
                Lat = 47.66083m,
                Long = -122.415282m
            },
            new Park()
            {
                Id = 3,
                Name = "Lincoln Park",
                Address = "8011 Fauntleroy Wa SW",
                Lat = 47.531176m,
                Long = -122.396012m
            },
            new Park()
            {
                Id = 4,
                Name = "Washington Park Arboretum",
                Address = "2300 Arboretum Dr E",
                Lat = 47.636477m,
                Long = -122.294835m
            },

        };
    }
}
