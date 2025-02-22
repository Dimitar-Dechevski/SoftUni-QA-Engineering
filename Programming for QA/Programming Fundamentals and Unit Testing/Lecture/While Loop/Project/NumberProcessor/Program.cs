namespace NumberProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while (!command.Equals("End"))
            {
                if (command.Equals("Inc"))
                {
                    number++;
                }
                else if (command.Equals("Dec"))
                {
                    number--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(number);
        }
    }
}
