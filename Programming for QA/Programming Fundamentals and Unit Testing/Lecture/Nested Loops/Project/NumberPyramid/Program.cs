namespace NumberPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int numberPerRow = 1;
            int numberCounter = 1;

            while (numberCounter <= n)
            {
                for (int i = 0; i < numberPerRow; i++)
                {
                    if (numberCounter <= n)
                    {
                        Console.Write($"{numberCounter} ");
                    }
                    else
                    {
                        break;
                    }
                    numberCounter++;
                }
                numberPerRow++;
                Console.WriteLine();
            }

        }
    }
}
