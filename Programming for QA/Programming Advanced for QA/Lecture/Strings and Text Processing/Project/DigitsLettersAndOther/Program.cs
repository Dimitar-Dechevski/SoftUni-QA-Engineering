using System.Text;

namespace DigitsLettersAndOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder otherCharacters = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (char.IsDigit(symbol))
                {
                    digits.Append(symbol);
                }
                else if (char.IsLetter(symbol))
                {
                    letters.Append(symbol);
                }
                else
                {
                    otherCharacters.Append(symbol);
                }

            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(otherCharacters);

        }
    }
}
