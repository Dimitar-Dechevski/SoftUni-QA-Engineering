namespace CountLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int upperLetters = 0;
            int lowerLetters = 0;
            int singleSpaces = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (symbol >= 'a' && symbol <= 'z')
                {
                    lowerLetters++;
                }
                else if (symbol >= 'A' && symbol <= 'Z')
                {
                    upperLetters++;
                }
                else
                {
                    singleSpaces++;
                }
            }

            Console.WriteLine(upperLetters);
            Console.WriteLine(lowerLetters);
            Console.WriteLine(singleSpaces);

        }
    }
}
