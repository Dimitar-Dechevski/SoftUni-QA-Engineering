namespace CalculateFactorialNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                int factorial = 1;

                for (int j = 1; j <= currentNumber; j++)
                {
                    factorial *= j;
                }

                Console.WriteLine(factorial);

            }

        }
    }
}
