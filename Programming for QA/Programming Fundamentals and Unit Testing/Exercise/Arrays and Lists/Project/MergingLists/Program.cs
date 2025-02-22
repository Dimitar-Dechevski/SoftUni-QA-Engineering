namespace MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> finalList = new List<int>();

            if (firstList.Count >= secondList.Count)
            {
                for (int i = 0; i < firstList.Count; i++)
                {
                    if (i < secondList.Count)
                    {
                        finalList.Add(firstList[i]);
                        finalList.Add(secondList[i]);
                    }
                    else
                    {
                        finalList.Add(firstList[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < secondList.Count; i++)
                {
                    if (i < firstList.Count)
                    {
                        finalList.Add(firstList[i]);
                        finalList.Add(secondList[i]);
                    }
                    else
                    {
                        finalList.Add(secondList[i]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", finalList));

        }
    }
}
