namespace MagicNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (int k = 1; k <= n; k++)
                    {
                        int firstPart = i;
                        int secondPart = j;
                        int thirdPart = k;
                        int magic = i * j * k;
                        int number = int.Parse($"{firstPart}{secondPart}{thirdPart}");

                        if (magic == n && number > 99 && number < 1000)
                        {
                            Console.Write($"{number} ");
                        }
                    }
                }
            }
        }
    }
}
