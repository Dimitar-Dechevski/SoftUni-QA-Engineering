using System.Diagnostics.Metrics;

namespace VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int output = VowelsCounter(input);
            Console.WriteLine(output);
        }

        static int VowelsCounter(string input)
        {
            int counter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                switch (symbol)
                {
                    case 'a':
                    case 'A':
                    case 'o':
                    case 'O':
                    case 'e':
                    case 'E':
                    case 'i':
                    case 'I':
                    case 'u':
                    case 'U':
                        counter++;
                        break;
                }
            }
            return counter;
        }
    }
}

