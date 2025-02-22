namespace TicketPrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeOfTicket = Console.ReadLine();

            if (typeOfTicket.Equals("student"))
            {
                double ticketPrice = 1;
                Console.WriteLine($"${ticketPrice:F2}");
            } 
            else if (typeOfTicket.Equals("regular")) 
            {
                double ticketPrice = 1.60;
                Console.WriteLine($"${ticketPrice:F2}");
            } 
            else
            {
                Console.WriteLine("Invalid ticket type!");
            }
        }
    }
}
