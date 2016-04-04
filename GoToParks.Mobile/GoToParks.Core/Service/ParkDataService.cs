using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoToParks.Core.Service
{
    public class ParkDataService
    {
        private static ParkRepository parkRepository = new ParkRepository();
        public ParkDataService()
        {

        }

        public List<Park> GetAllParks()
        {
            return parkRepository.GetAllParks();
        }

        public Park GetParkById(int id)
        {
            return parkRepository.GetParkById(id);
        }
    }
}
