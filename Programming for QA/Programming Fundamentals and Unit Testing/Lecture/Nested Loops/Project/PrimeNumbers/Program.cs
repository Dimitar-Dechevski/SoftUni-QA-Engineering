namespace PrimeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            bool isPrime = true;

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    else
                    {
                        isPrime = true;
                    }
                }

                if (isPrime)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}