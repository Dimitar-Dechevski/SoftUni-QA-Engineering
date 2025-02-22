namespace ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split(" ")
                 .Select(int.Parse)
                 .ToList();

            string input = Console.ReadLine();

            while (!input.Equals("end"))
            {
                string[] tokens = input.Split(" ");
                string command = tokens[0];

                if (command.Equals("Contains"))
                {
                    ContainsFunction(numbers, tokens);
                }
                else if (command.Equals("PrintEven"))
                {
                    PrintEvenFunction(numbers);
                }
                else if (command.Equals("PrintOdd"))
                {
                    PrintOddFunction(numbers);
                }
                else if (command.Equals("GetSum"))
                {
                    GetSumFunction(numbers);
                }
                else if (command.Equals("Filter"))
                {
                    numbers = FilterFunction(numbers, tokens);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static List<int> FilterFunction(List<int> numbers, string[] tokens)
        {
            string condition = tokens[1];
            int element = int.Parse(tokens[2]);

            switch (condition)
            {
                case "<":
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        int item = numbers[i];

                        if (!(item < element))
                        {
                            numbers.Remove(item);
                            i--;
                        }
                    }
                    break;
                case ">":
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        int item = numbers[i];

                        if (!(item > element))
                        {
                            numbers.Remove(item);
                            i--;
                        }
                    }
                    break;
                case ">=":
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        int item = numbers[i];

                        if (!(item >= element))
                        {
                            numbers.Remove(item);
                            i--;
                        }
                    }
                    break;
                case "<=":
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        int item = numbers[i];

                        if (!(item <= element))
                        {
                            numbers.Remove(item);
                            i--;
                        }
                    }
                    break;
            }

            return numbers;
        }

        private static void GetSumFunction(List<int> numbers)
        {
            int sum = 0;
            foreach (int item in numbers)
            {
                sum += item;
            }
            Console.WriteLine(sum);
        }

        private static void PrintOddFunction(List<int> numbers)
        {
            foreach (int item in numbers)
            {
                if (item % 2 == 1)
                {
                    Console.Write($"{item} ");
                }
            }
            Console.WriteLine();
        }

        private static void PrintEvenFunction(List<int> numbers)
        {
            foreach (int item in numbers)
            {
                if (item % 2 == 0)
                {
                    Console.Write($"{item} ");
                }
            }
            Console.WriteLine();
        }

        private static void ContainsFunction(List<int> numbers, string[] tokens)
        {
            int element = int.Parse(tokens[1]);

            if (numbers.Contains(element))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }
    }
}
