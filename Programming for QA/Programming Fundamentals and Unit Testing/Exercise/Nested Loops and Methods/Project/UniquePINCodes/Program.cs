using System.Diagnostics.Metrics;

namespace UniquePINCodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstDigit = int.Parse(Console.ReadLine());
            int secondDigit = int.Parse(Console.ReadLine());
            int thirdDigit = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 1; i <= firstDigit; i++)
            {
                for (int j = 1; j <= secondDigit; j++)
                {
                    for (int k = 1; k <= thirdDigit; k++)
                    {
                        if (i % 2 == 0 && k % 2 == 0)
                        {
                            for (int l = 2; l <= 7; l++)
                            {
                                if (j % l == 0)
                                {
                                    counter++;
                                }
                            }
                            if (counter == 1)
                            {
                                Console.WriteLine($"{i}{j}{k}");
                            }
                            counter = 0;
                        }
                    }
                }
            }
        }
    }
}
