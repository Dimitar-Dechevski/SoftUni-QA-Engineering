namespace DepositCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double depositAmount = double.Parse(Console.ReadLine());
            int depositPeriodInMonths = int.Parse(Console.ReadLine());
            double annualInterestRate = double.Parse(Console.ReadLine());

            double amount = depositAmount + depositPeriodInMonths * (depositAmount * (annualInterestRate / 100)) / 12;

            Console.WriteLine(amount);
        }
    }
}
