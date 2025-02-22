namespace SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            double result = 0;

            for (int i = 0; i < n; i++)
            {
                double number = double.Parse(Console.ReadLine());
                result += number;
            }

            Console.WriteLine(result);

        }
    }
}
