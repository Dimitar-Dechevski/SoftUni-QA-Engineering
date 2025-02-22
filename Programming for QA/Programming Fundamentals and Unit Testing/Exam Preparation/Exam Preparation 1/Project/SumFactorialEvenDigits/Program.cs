namespace SumFactorialEvenDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;

            while (number > 0)
            {
                int factorial = 1;
                int digit = number % 10;

                if (digit % 2 == 0)
                {
                    for (int i = digit; i > 0; i--)
                    {
                        factorial *= i;
                    }
                    sum += factorial;
                }

                number /= 10;
            }

            Console.WriteLine(sum);

        }
    }
}
