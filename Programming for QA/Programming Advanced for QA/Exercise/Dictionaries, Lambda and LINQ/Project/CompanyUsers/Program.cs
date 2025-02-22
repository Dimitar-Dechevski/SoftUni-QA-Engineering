namespace CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> employees = new Dictionary<string, List<string>>();

            while (!input.Equals("End"))
            {
                string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string company = tokens[0];
                string userId = tokens[1];

                if (employees.ContainsKey(company))
                {
                    if (employees[company].Contains(userId))
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        employees[company].Add(userId);
                    }
                }
                else
                {
                    employees.Add(company, new List<string>());
                    employees[company].Add(userId);
                }

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, List<string>> entry in employees)
            {
                Console.WriteLine($"{entry.Key}");
                entry.Value.ForEach(employee => Console.WriteLine($"-- {employee}"));
            }

        }
    }
}
