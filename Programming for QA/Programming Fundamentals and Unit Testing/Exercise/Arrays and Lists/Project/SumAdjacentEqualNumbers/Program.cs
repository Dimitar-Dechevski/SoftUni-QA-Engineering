namespace SumAdjacentEqualNumbers
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
                if (i + 1 <= numbers.Count - 1)
                {
                    int firstItem = numbers[i];
                    int secondItem = numbers[i + 1];

                    if (firstItem == secondItem)
                    {
                        int sum = firstItem + secondItem;
                        numbers.Remove(firstItem);
                        numbers.Remove(secondItem);
                        numbers.Insert(i, sum);
                        i = -1;
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
