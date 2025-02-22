namespace MiddleElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int middleIndex = (numbers.Length - 1) / 2;
            int result = numbers[middleIndex] + numbers[middleIndex + 1];
            double average = result / 2.00;

            Console.WriteLine($"{average:F2}");

        }
    }
}
