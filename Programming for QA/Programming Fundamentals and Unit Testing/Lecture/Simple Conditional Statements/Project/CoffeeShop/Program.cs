using System.Diagnostics;

namespace CoffeeShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string extra = Console.ReadLine();
            double priceCoffee = 1;
            double priceTea = 0.60;
            double priceSugar = 0.40;
            double total = 0;

            if (drink.Equals("coffee"))
            {
                total += priceCoffee;
            } 
            else if (drink.Equals("tea"))
            {
                total += priceTea;
            }

            if (extra.Equals("sugar"))
            {
                total += priceSugar;
            }

            Console.WriteLine($"Final price: ${total:F2}");
        }
    }
}
