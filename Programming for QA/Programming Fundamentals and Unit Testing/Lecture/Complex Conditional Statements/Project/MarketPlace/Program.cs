namespace MarketPlace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;


            if (day.Equals("Weekday"))
            {
                switch (product)
                {
                    case "Banana":
                        price = 2.50;
                        Console.WriteLine($"{price:F2}");
                        break;
                    case "Apple":
                        price = 1.30;
                        Console.WriteLine($"{price:F2}");
                        break;
                    case "Kiwi":
                        price = 2.20;
                        Console.WriteLine($"{price:F2}");
                        break;
                }
            }
            else if (day.Equals("Weekend"))
            {
                switch (product)
                {
                    case "Banana":
                        price = 2.70;
                        Console.WriteLine($"{price:F2}");
                        break;
                    case "Apple":
                        price = 1.60;
                        Console.WriteLine($"{price:F2}");
                        break;
                    case "Kiwi":
                        price = 3.00;
                        Console.WriteLine($"{price:F2}");
                        break;
                }
            }
        }
    }
}
