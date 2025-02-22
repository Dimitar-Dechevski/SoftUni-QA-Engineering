using System.Reflection;

namespace VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Car> listOfCars = new List<Car>();
            List<Truck> listOfTrucks = new List<Truck>();
            List<Catalog> listOfCarsAndTrucks = new List<Catalog>();

            while (!input.Equals("end"))
            {
                string[] tokens = input.Split("/", StringSplitOptions.RemoveEmptyEntries);
                string type = tokens[0];
                string brand = tokens[1];
                string model = tokens[2];

                if (type.Equals("Car"))
                {
                    int horsePower = int.Parse(tokens[3]);
                    Car car = new Car(brand, model, horsePower);
                    listOfCars.Add(car);
                }
                else if (type.Equals("Truck"))
                {
                    int weight = int.Parse(tokens[3]);
                    Truck truck = new Truck(brand, model, weight);
                    listOfTrucks.Add(truck);
                }

                input = Console.ReadLine();
            }

            listOfCars = listOfCars.OrderBy(c => c.Brand).ToList();
            listOfTrucks = listOfTrucks.OrderBy(t => t.Brand).ToList();

            Catalog catalog = new Catalog(listOfTrucks, listOfCars);
            listOfCarsAndTrucks.Add(catalog);

            foreach (Catalog catalogs in listOfCarsAndTrucks)
            {
                if (catalogs.ListOfTrucks.Count == 0)
                {
                    Console.WriteLine("Cars:");

                    foreach (Car car in catalogs.ListOfCars)
                    {
                        Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                    }
                }
                else if (catalogs.ListOfCars.Count == 0)
                {
                    Console.WriteLine("Trucks:");

                    foreach (Truck truck in catalogs.ListOfTrucks)
                    {
                        Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                    }
                }
                else
                {
                    Console.WriteLine("Cars:");

                    foreach (Car car in catalogs.ListOfCars)
                    {
                        Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                    }

                    Console.WriteLine("Trucks:");

                    foreach (Truck truck in catalogs.ListOfTrucks)
                    {
                        Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                    }
                }
            }

        }
    }
}
