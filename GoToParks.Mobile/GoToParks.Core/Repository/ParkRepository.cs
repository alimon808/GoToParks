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
            IEnumerable<Park> park = from p in parks
                                     where p.Id == id
                                     select p;
            return park.FirstOrDefault();
        }

        private static List<Park> parks = new List<Park>()
        {
            new Park()
            {
                Id = 1,
                Name = "Seward Park",
                Address = "5900 Lake Washington Blvd S",
                Hours = "6am - 10pm",
                Lat = 47.54923f,
                Long = -122.250639f,
                Rating = 100
            },
            new Park()
            {
                Id = 2,
                Name = "Discovery Park",
                Address = "3801 Discover Park Blvd",
                Hours = "4am - 11:30pm",
                Lat = 47.66083f,
                Long = -122.415282f,
                Rating = 99
            },
            new Park()
            {
                Id = 3,
                Name = "Lincoln Park",
                Address = "8011 Fauntleroy Wa SW",
                Hours = "4am - 11:30pm",
                Lat = 47.531176f,
                Long = -122.396012f,
                Rating = 90
            },
            new Park()
            {
                Id = 4,
                Name = "Washington Park Arboretum",
                Address = "2300 Arboretum Dr E",
                Hours = "dawn - dusk",
                Lat = 47.636477f,
                Long = -122.294835f,
                Rating = 92
            },
            new Park()
            {
                Id = 5,
                Name = "Volunteer Park",
                Address = "1247 15th Ave E",
                Hours = "6am - 10pm",
                Lat = 47.630378f,
                Long = -122.315568f,
                Rating = 95
            },
            new Park()
            {
                Id = 6,
                Name = "Boren Park",
                Address = "1606 15th Ave E",
                Hours = "4am - 11:30pm",
                Lat = 47.635274f,
                Long = -122.311628f,
                Rating = 50
            },
            new Park()
            {
                Id = 7,
                Name = "Montlake Playfield",
                Address = "1618 E Calhoun St",
                Hours = "4am - 11:30pm",
                Lat = 47.642407f,
                Long = -122.310081f,
                Rating = 60
            },
            new Park()
            {
                Id = 8,
                Name = "Interlaken Park",
                Address = "2451 Delmar Dr E",
                Hours = "4am - 11:30pm",
                Lat = 47.636257f,
                Long = -122.308316f,
                Rating = 45
            },
            new Park()
            {
                Id = 9,
                Name = "West Monlake Park",
                Address = "2815 W Park Dr E",
                Hours = "4am - 11:30pm",
                Lat = 47.646219f,
                Long = -122.30982f,
                Rating = 30
            },
            new Park()
            {
                Id = 10,
                Name = "Cal Anderson Park",
                Address = "1635 11th Ave",
                Hours = "4am - 11:30pm",
                Lat = 47.617013f,
                Long = -122.319134f,
                Rating = 85
            },
            new Park()
            {
                Id = 11,
                Name = "Schmitz Preserve Park",
                Address = "5551 SW Admiral Way",
                Hours = "6am - 11pm",
                Lat = 47.574375f,
                Long = -122.400425f,
                Rating = 66
            },
            new Park()
            {
                Id = 12,
                Name = "Alki Playground",
                Address = "5817 SW Lander St",
                Hours = "4am - 11:30pm",
                Lat = 47.578497f,
                Long = -122.407312f,
                Rating = 50
            },
            new Park()
            {
                Id = 13,
                Name = "Cormorant Cove",
                Address = "3701 Beach Dr SW",
                Hours = "4am - 11:30pm",
                Lat = 47.570984f,
                Long = -122.412089f,
                Rating = 49
            },
            new Park()
            {
                Id = 14,
                Name = "Emma Schmitz Memorial Overlook",
                Address = "4503 Beach Dr SW",
                Hours = "4am - 11:30pm",
                Lat = 47.562898f,
                Long = -122.40712f,
                Rating = 44
            },
            new Park()
            {
                Id = 15,
                Name = "Camp Long",
                Address = "5200 35th Ave SW",
                Hours = "10am - 6pm",
                Lat = 47.556242f,
                Long = -122.373161f,
                Rating = 62
            }
        };
    }
}
