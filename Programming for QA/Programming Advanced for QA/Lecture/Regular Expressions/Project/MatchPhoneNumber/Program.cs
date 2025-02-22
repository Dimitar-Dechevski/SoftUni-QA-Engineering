using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = "[+]359(?<separator>[\\ \\-])2\\k<separator>[0-9]{3}\\k<separator>[0-9]{4}\\b";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
