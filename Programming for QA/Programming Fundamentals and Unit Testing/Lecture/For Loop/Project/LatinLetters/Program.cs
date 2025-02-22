namespace LatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {

            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());

            for (char symbol = firstLetter; symbol <= secondLetter; symbol++)
            {
                Console.Write(symbol + " ");
            }
        }
    }
}
