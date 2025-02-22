namespace SpecialBonus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stopNumber = int.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            int previousNumber = 0;

            while (stopNumber != number)
            {
                previousNumber = number;
                number = int.Parse(Console.ReadLine());
            }

            double result = previousNumber + previousNumber * 0.20;
            Console.WriteLine($"{result:F0}");
        }
    }
}
