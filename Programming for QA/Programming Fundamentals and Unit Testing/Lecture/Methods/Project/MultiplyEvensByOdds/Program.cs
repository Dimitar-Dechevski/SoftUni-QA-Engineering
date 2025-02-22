namespace MultiplyEvensByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int number = Math.Abs(input);
            int evenSum = GetSumOfEvenDigits(number);
            int oddSum = GetSumOfOddDigits(number);
            int result = GetMultipleOfEvenAndOdds(evenSum, oddSum);
            Console.WriteLine(result);
        }

        static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            int result = evenSum * oddSum;
            return result;
        }

        static int GetSumOfEvenDigits(int number)
        {
            int sum = 0;

            while (number > 0)
            {
                int digit = number % 10;
                if (digit % 2 == 0)
                {
                    sum += digit;
                }
                number /= 10;
            }

            return sum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int sum = 0;

            while (number > 0)
            {
                int digit = number % 10;
                if (digit % 2 == 1)
                {
                    sum += digit;
                }
                number /= 10;
            }

            return sum;
        }

    }
}
