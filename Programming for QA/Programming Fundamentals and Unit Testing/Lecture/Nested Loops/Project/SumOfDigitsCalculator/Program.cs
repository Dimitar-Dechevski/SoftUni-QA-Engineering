namespace SumOfDigitsCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int result = 0;

            while (!input.Equals("End"))
            {
                int number = int.Parse(input);

                while (number > 0)
                {
                    int digit = number % 10;
                    result += digit;
                    number /= 10;
                }

                Console.WriteLine($"Sum of digits = {result}");
                result = 0;
                input = Console.ReadLine();
            }

            Console.WriteLine("Goodbye");
        }
    }
}
