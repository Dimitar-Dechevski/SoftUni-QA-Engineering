namespace MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            int result = MathPower(number, power);
            Console.WriteLine(result);
        }

        static int MathPower(int number, int power)
        {
            int result = 1;

            for (int i = 0; i < power; i++)
            {
                result *= number;
            }

            return result;
        }
    }
}
