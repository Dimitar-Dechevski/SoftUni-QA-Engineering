namespace StoreBoxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Box> storage = new List<Box>();


            while (!input.Equals("end"))
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string serialNumber = tokens[0];
                string itemName = tokens[1];
                int itemQuantity = int.Parse(tokens[2]);
                double itemPrice = double.Parse(tokens[3]);
                double boxPrice = itemQuantity * itemPrice;

                Item item = new Item(itemName, itemPrice);
                Box box = new Box(serialNumber, item, itemQuantity, boxPrice);
                storage.Add(box);

                input = Console.ReadLine();
            }

            storage = storage.OrderByDescending(e => e.PriceBox).ToList();

            foreach (Box box in storage)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceBox:F2}");
            }

        }
    }
}
