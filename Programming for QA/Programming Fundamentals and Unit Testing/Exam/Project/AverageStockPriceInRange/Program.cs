namespace AverageStockPriceInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int startIndex = int.Parse(Console.ReadLine());
            int endIndex = int.Parse(Console.ReadLine());
            double sum = 0;
            int counter = 0;

            for (int i = startIndex; i <= endIndex; i++)
            {
                int currentNumber = numbers[i];
                sum += currentNumber;
                counter++;
            }

            double averageSum = sum / counter;
            Console.WriteLine($"{averageSum:F2}");

        }
    }
}
