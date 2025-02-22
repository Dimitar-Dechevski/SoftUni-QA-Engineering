namespace Gauss_Trick
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
                if (numbers.Count > 1)
                {
                    int firstNumber = numbers[i];
                    int secondNumber = numbers[numbers.Count - i - 1];
                    int sum = firstNumber + secondNumber;
                    Console.Write($"{sum} ");
                    numbers.Remove(firstNumber);
                    numbers.Remove(secondNumber);
                    i--;
                }
                else
                {
                    Console.Write(string.Join(" ", numbers));
                }
            }

        }
    }
}
