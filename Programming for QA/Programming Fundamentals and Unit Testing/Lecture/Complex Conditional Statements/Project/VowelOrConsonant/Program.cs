namespace VowelOrConsonant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char symbol = char.Parse(Console.ReadLine());

            if (symbol.Equals('A') || symbol.Equals('a')
                || symbol.Equals('E') || symbol.Equals('e')
                || symbol.Equals('I') || symbol.Equals('i')
                || symbol.Equals('O') || symbol.Equals('o')
                || symbol.Equals('U') || symbol.Equals('u'))
            {
                Console.WriteLine("Vowel");
            }
            else
            {
                Console.WriteLine("Consonant");
            }
        }
    }
}
