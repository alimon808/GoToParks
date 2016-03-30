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

        public Park GetParkById(int id)
        {
            IEnumerable<Park> park = from p in parks where p.Id == id select p;
            return park.FirstOrDefault();
        }

        private static List<Park> parks = new List<Park>()
        {
            new Park()
            {
                Id = 1,
                Name = "Seward Park",
                Address = "5900 Lake Washington Blvd S",
                Hours = "6am - 9pm",
                Lat = 47.54923f,
                Long = -122.250639f
            },
            new Park()
            {
                Id = 2,
                Name = "Discover Park",
                Address = "3801 Discover Park Blvd",
                Hours = "8am - 10pm",
                Lat = 47.66083f,
                Long = -122.415282f
            },
            new Park()
            {
                Id = 3,
                Name = "Lincoln Park",
                Address = "8011 Fauntleroy Wa SW",
                Hours = "7am - 7pm",
                Lat = 47.531176f,
                Long = -122.396012f
            },
            new Park()
            {
                Id = 4,
                Name = "Washington Park Arboretum",
                Address = "2300 Arboretum Dr E",
                Hours = "5am - 10pm",
                Lat = 47.636477f,
                Long = -122.294835f
            },

        };
    }
}
