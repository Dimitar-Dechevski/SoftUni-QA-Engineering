namespace ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (!input.Equals("end"))
            {
                string reversedInput = "";

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reversedInput += input[i];
                }

                Console.WriteLine($"{input} = {reversedInput}");
                input = Console.ReadLine();
            }

        }
    }
}
