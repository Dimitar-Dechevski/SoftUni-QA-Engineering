namespace RemoveNegativesAndReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                int item = numbers[i];

                if (item < 0)
                {
                    numbers.Remove(item);
                    i--;
                }

            }

            numbers.Reverse();

            if (numbers.Count > 0)
            {
                Console.Write(string.Join(" ", numbers));
            }
            else
            {
                Console.WriteLine("empty");
            }

        }
    }
}
