namespace TravelSavings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double total = 0;

            while (!input.Equals("End"))
            {
                string destination = input;
                double budget = double.Parse(Console.ReadLine());

                while (budget > total)
                {
                    input = Console.ReadLine();
                    double amount = double.Parse(input);
                    total += amount;
                    Console.WriteLine($"Collected: {total:F2}");
                }

                Console.WriteLine($"Going to {destination}!");
                total = 0;
                input = Console.ReadLine();
            }
        }
    }
}
