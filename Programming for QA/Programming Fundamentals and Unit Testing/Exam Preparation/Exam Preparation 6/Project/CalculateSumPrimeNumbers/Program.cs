namespace CalculateSumPrimeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            bool isPrime = true;

            while (n > 0)
            {
                int number = int.Parse(Console.ReadLine());

                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    sum += number;

                }
                else
                {
                    isPrime = true;
                }

                n--;
            }

            Console.WriteLine(sum);

        }
    }
}
