namespace AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double balance = 0;

            while (!input.Equals("End"))
            {
                double money = double.Parse(input);
                balance = balance + money;

                if (money < 0)
                {
                    Console.WriteLine($"Decrease: {Math.Abs(money):F2}");
                }
                else
                {
                    Console.WriteLine($"Increase: {money:F2}");
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Balance: {balance:F2}");
        }
    }
}
