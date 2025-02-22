namespace TopIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                bool isTop = true;
                int firstItem = numbers[i];

                for (int j = i + 1; j < numbers.Count; j++)
                {
                    int secondItem = numbers[j];

                    if (firstItem > secondItem)
                    {
                        isTop = true;
                    }
                    else
                    {
                        isTop = false;
                        break;
                    }
                }

                if (isTop)
                {
                    Console.Write($"{firstItem} ");
                }
            }

        }
    }
}
