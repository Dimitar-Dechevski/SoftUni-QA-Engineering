namespace SumAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split(" ")
                 .Select(int.Parse)
                 .ToArray();

            int sum = 0;

            foreach (int item in numbers)
            {
                sum += item;
            }

            Console.WriteLine(sum);

        }
    }
}
