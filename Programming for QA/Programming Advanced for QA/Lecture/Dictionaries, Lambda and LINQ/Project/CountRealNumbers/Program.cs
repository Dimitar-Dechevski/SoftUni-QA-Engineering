namespace CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            SortedDictionary<double, int> numbers = new SortedDictionary<double, int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (numbers.ContainsKey(input[i]))
                {
                    numbers[input[i]] = numbers[input[i]] + 1;
                }
                else
                {
                    numbers.Add(input[i], 1);
                }
            }

            foreach (KeyValuePair<double, int> entry in numbers)
            {
                Console.WriteLine($"{entry.Key} -> {entry.Value}");
            }

        }
    }
}
