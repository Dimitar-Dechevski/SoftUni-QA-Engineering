namespace CondenseArrayToNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            while (numbers.Count > 1)
            {
                int counter = numbers.Count - 1;

                for (int i = 0; i < counter; i++)
                {
                    int firstNumber = numbers[i];
                    int secondNumber = numbers[i + 1];
                    int sum = firstNumber + secondNumber;
                    numbers.Add(sum);
                }

                numbers.RemoveRange(0, counter + 1);
            }

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
