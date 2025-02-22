namespace ListManipulationBasics
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

                if (command.Equals("Add"))
                {
                    AddFunction(numbers, tokens);
                }
                else if (command.Equals("Remove"))
                {
                    RemoveFunction(numbers, tokens);
                }
                else if (command.Equals("RemoveAt"))
                {
                    RemoveAtFunction(numbers, tokens);
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
            int position = int.Parse(tokens[2]);
            numbers.Insert(position, element);
        }

        private static void RemoveAtFunction(List<int> numbers, string[] tokens)
        {
            int element = int.Parse(tokens[1]);
            numbers.RemoveAt(element);
        }

        private static void RemoveFunction(List<int> numbers, string[] tokens)
        {
            int element = int.Parse(tokens[1]);
            numbers.Remove(element);
        }

        private static void AddFunction(List<int> numbers, string[] tokens)
        {
            int element = int.Parse(tokens[1]);
            numbers.Add(element);
        }
    }
}
