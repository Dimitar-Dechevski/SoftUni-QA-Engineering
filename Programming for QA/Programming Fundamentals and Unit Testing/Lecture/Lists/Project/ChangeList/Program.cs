namespace ChangeList
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

                if (command.Equals("Delete"))
                {
                    DeleteFunction(numbers, tokens);
                }
                else if (command.Equals("Insert"))
                {
                    InsertFunction(numbers, tokens);
                }

                input = Console.ReadLine();
            }

            Console.Write(string.Join(" ", numbers));

        }

        private static void InsertFunction(List<int> numbers, string[] tokens)
        {
            int element = int.Parse(tokens[1]);
            int postion = int.Parse(tokens[2]);
            numbers.Insert(postion, element);
        }

        private static void DeleteFunction(List<int> numbers, string[] tokens)
        {
            int element = int.Parse(tokens[1]);

            while (numbers.Contains(element))
            {
                numbers.Remove(element);
            }
        }
    }
}
