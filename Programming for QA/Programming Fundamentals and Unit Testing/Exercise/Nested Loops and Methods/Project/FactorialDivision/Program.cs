namespace FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int firstSum = FactorialOfNumber(firstNumber);
            int secondSum = FactorialOfNumber(secondNumber);
            int output = firstSum / secondSum;
            Console.WriteLine(output);
        }

        static int FactorialOfNumber(int number)
        {
            int sum = 1;

            for (int i = 1; i <= number; i++)
            {
                sum *= i;
            }

            return sum;
        }

    }
}

