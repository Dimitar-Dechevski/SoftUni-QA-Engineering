namespace Rotations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rotations = int.Parse(Console.ReadLine());
            int[] rotatedNumbers = new int[numbers.Length];

            while (rotations > 0)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (i == numbers.Length - 1)
                    {
                        rotatedNumbers[0] = numbers[i];
                    }
                    else
                    {
                        rotatedNumbers[i + 1] = numbers[i];
                    }
                }

                numbers = rotatedNumbers;
                rotatedNumbers = new int[numbers.Length];
                rotations--;
            }

            Console.WriteLine(string.Join(", ", numbers));

        }
    }
}
