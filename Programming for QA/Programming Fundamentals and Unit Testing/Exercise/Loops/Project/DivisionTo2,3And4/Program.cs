namespace DivisionTo2_3And4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double percentStep = (double)100 / n;
            double percentForTwo = 0;
            double percentForThree = 0;
            double percentForFour = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    percentForTwo += percentStep;
                }
                if (number % 3 == 0)
                {
                    percentForThree += percentStep;
                }
                if (number % 4 == 0)
                {
                    percentForFour += percentStep;
                }
            }

            Console.WriteLine($"{percentForTwo:F2}%");
            Console.WriteLine($"{percentForThree:F2}%");
            Console.WriteLine($"{percentForFour:F2}%");
        }
    }
}
