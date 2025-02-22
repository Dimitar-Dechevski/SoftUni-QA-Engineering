namespace SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> parking = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if (command.Equals("register"))
                {
                    string username = tokens[1];
                    string licensePlateNumber = tokens[2];

                    if (parking.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parking[username]}");
                    }
                    else
                    {
                        parking.Add(username, licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                }
                else if (command.Equals("unregister"))
                {
                    string username = tokens[1];

                    if (parking.ContainsKey(username))
                    {
                        parking.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach (KeyValuePair<string, string> entry in parking)
            {
                Console.WriteLine($"{entry.Key} => {entry.Value}");
            }

        }
    }
}
