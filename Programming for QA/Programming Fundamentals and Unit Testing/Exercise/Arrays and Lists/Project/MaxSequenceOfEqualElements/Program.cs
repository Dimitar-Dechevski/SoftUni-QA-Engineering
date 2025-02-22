using System.Security.Cryptography;

namespace MaxSequenceOfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            List<int> currentSequence = new List<int>();
            List<int> sequence = new List<int>();
            int currentIndex = 0;
            int index = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                int firstItem = numbers[i];
                currentSequence.Add(firstItem);
                currentIndex = i;

                for (int j = i + 1; j < numbers.Count; j++)
                {
                    int secondItem = numbers[j];

                    if (firstItem != secondItem)
                    {
                        break;
                    }

                    currentSequence.Add(secondItem);
                }

                if (currentSequence.Count > sequence.Count)
                {
                    sequence = currentSequence;
                    index = currentIndex;
                }
                else if (currentSequence.Count == sequence.Count)
                {
                    if (currentIndex < index)
                    {
                        index = currentIndex;
                        sequence = currentSequence;
                    }
                }

                currentSequence = new List<int>();
            }

            Console.WriteLine(string.Join(" ", sequence));

        }
    }
}
