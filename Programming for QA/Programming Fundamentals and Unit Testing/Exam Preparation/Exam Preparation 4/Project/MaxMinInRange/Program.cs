namespace MaxMinInRange
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
            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;

            for (int i = startIndex; i <= endIndex; i++)
            {
                int currentNumber = numbers[i];

                if (currentNumber < minNumber)
                {
                    minNumber = currentNumber;
                }

                if (currentNumber > maxNumber)
                {
                    maxNumber = currentNumber;
                }

            }

            int result = maxNumber + minNumber;
            Console.WriteLine(result);

        }
    }
}
