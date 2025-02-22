using System.ComponentModel.Design;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> orders = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();

            while (!command.Equals("buy"))
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string product = tokens[0];
                string priceAndQuantity = tokens[1] + " " + tokens[2];

                if (orders.ContainsKey(product))
                {
                    orders[product].Add(priceAndQuantity);
                }
                else
                {
                    orders.Add(product, new List<string>());
                    orders[product].Add(priceAndQuantity);
                }

                command = Console.ReadLine();
            }

            foreach (KeyValuePair<string, List<string>> entry in orders)
            {
                double price = 0;
                int quantity = 0;
                for (int i = 0; i < entry.Value.Count; i++)
                {
                    string[] tokens = entry.Value[i].Split(" ");
                    price = double.Parse(tokens[0]);
                    quantity += int.Parse(tokens[1]);
                }

                double total = price * quantity;
                Console.WriteLine($"{entry.Key} -> {total:F2}");

            }

        }
    }
}
