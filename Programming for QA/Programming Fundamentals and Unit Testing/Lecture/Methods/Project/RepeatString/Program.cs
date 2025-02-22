namespace RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repeater = int.Parse(Console.ReadLine());
            string output = RepeatString(input, repeater);
            Console.WriteLine(output);
        }

        static string RepeatString(string input, int repeater)
        {
            string result = "";

            for (int i = 0; i < repeater; i++)
            {
                result += input;
            }

            return result;
        }
    }
}
