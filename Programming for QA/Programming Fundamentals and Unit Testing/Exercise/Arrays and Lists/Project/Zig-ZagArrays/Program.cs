namespace Zig_ZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] firstArray = new int[n];
            int[] secondArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split(" ");
                int firstNumber = int.Parse(tokens[0]);
                int secondNumber = int.Parse(tokens[1]);

                if (i % 2 == 0)
                {
                    firstArray[i] = firstNumber;
                    secondArray[i] = secondNumber;
                }
                else
                {
                    firstArray[i] = secondNumber;
                    secondArray[i] = firstNumber;
                }
            }

            Console.WriteLine(string.Join(" ", firstArray));
            Console.WriteLine(string.Join(" ", secondArray));

        }
    }
}
