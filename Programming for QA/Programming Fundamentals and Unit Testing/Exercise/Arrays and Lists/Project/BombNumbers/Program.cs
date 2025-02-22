namespace BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split(" ")
                 .Select(int.Parse)
                 .ToList();

            string input = Console.ReadLine();
            string[] tokens = input.Split(" ");

            int bombNumber = int.Parse(tokens[0]);
            int bombPower = int.Parse(tokens[1]);

            while (numbers.Contains(bombNumber))
            {
                int bombIndex = numbers.IndexOf(bombNumber);
                int leftIndex = bombIndex - bombPower;
                int rightIndex = bombIndex + bombPower;

                if (rightIndex > numbers.Count - 1)
                {
                    rightIndex = numbers.Count - 1;
                }
                if (leftIndex < 0)
                {
                    leftIndex = 0;
                }

                int counterIndex = rightIndex - leftIndex + 1;
                numbers.RemoveRange(leftIndex, counterIndex);

            }

            int sum = 0;

            foreach (int item in numbers)
            {
                sum += item;
            }

            Console.WriteLine(sum);

        }
    }
}
