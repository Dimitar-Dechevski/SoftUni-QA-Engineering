namespace MinMaxValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = int.Parse(Console.ReadLine());
            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                int item = numbers[i];

                if (item > maxNumber)
                {
                    maxNumber = item;
                }
                if (item < minNumber)
                {
                    minNumber = item;
                }
            }

            Console.WriteLine(maxNumber);
            Console.WriteLine(minNumber);

        }
    }
}
