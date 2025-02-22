using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCatalogue
{
    internal class Catalog
    {
        public List<Truck> ListOfTrucks { get; set; }
        public List<Car> ListOfCars { get; set; }

        public Catalog(List<Truck> listOfTrucks, List<Car> listOfCars)
        {
            ListOfTrucks = listOfTrucks;
            ListOfCars = listOfCars;
        }

    }
}
