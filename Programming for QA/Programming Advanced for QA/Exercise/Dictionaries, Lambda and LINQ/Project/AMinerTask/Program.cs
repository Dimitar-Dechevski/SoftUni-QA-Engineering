namespace AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> resources = new Dictionary<string, double>();
            string command = Console.ReadLine();

            while (!command.Equals("stop"))
            {
                string resource = command;
                double quantity = double.Parse(Console.ReadLine());

                if (resources.ContainsKey(resource))
                {
                    resources[resource] += quantity;
                }
                else
                {
                    resources.Add(resource, quantity);
                }

                command = Console.ReadLine();
            }

            foreach (KeyValuePair<string, double> entry in resources)
            {
                Console.WriteLine($"{entry.Key} -> {entry.Value}");
            }

        }
    }
}
