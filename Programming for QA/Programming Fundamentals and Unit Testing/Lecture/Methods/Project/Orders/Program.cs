namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double result = Orders(product, quantity);
            Console.WriteLine($"{result:F2}");
        }

        static double Orders(string product, int quantity)
        {
            double price;
            double total = 0;

            switch (product)
            {
                case "coffee":
                    price = 1.50;
                    total = quantity * price;
                    break;
                case "water":
                    price = 1.00;
                    total = quantity * price;
                    break;
                case "coke":
                    price = 1.40;
                    total = quantity * price;
                    break;
                case "snacks":
                    price = 2.00;
                    total = quantity * price;
                    break;
            }

            return total;
        }
    }
}
