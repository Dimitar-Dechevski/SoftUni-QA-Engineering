namespace LetterCombinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char startSymbol = char.Parse(Console.ReadLine());
            char endSymbol = char.Parse(Console.ReadLine());
            char excludedSymbol = char.Parse(Console.ReadLine());
            int counter = 0;

            for (char i = startSymbol; i <= endSymbol; i++)
            {
                for (char j = startSymbol; j <= endSymbol; j++)
                {
                    for (char k = startSymbol; k <= endSymbol; k++)
                    {
                        if (i != excludedSymbol && j != excludedSymbol && k != excludedSymbol)
                        {
                            counter++;
                            Console.Write($"{i}{j}{k} ");
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine(counter);
        }
    }
}
