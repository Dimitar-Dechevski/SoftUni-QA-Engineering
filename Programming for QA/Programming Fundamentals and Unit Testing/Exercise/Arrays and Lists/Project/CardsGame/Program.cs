using System.Runtime.ExceptionServices;

namespace CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCards = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> secondPlayerCards = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < firstPlayerCards.Count; i++)
            {
                int firstItem = firstPlayerCards[i];
                int secondItem = secondPlayerCards[i];

                if (firstItem == secondItem)
                {
                    firstPlayerCards.Remove(firstItem);
                    secondPlayerCards.Remove(secondItem);
                    i--;
                }
                else if (firstItem > secondItem)
                {
                    firstPlayerCards.Remove(firstItem);
                    firstPlayerCards.Add(firstItem);
                    firstPlayerCards.Add(secondItem);
                    secondPlayerCards.Remove(secondItem);
                    i--;
                }
                else
                {
                    secondPlayerCards.Remove(secondItem);
                    secondPlayerCards.Add(secondItem);
                    secondPlayerCards.Add(firstItem);
                    firstPlayerCards.Remove(firstItem);
                    i--;
                }

                if (firstPlayerCards.Count == 0)
                {
                    int sum = 0;
                    foreach (int item in secondPlayerCards)
                    {
                        sum += item;
                    }

                    Console.WriteLine($"Second player wins! Sum: {sum}");
                    return;
                }
                else if (secondPlayerCards.Count == 0)
                {
                    int sum = 0;
                    foreach (int item in firstPlayerCards)
                    {
                        sum += item;
                    }

                    Console.WriteLine($"First player wins! Sum: {sum}");
                    return;
                }
            }

        }
    }
}
