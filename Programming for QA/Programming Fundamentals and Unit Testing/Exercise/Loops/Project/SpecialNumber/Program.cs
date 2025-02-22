namespace SpecialNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int number = input;
            bool isSpecial = false;

            while (input > 0)
            {
                int digit = input % 10;
                if (number % digit == 0)
                {
                    isSpecial = true;
                }
                else
                {
                    isSpecial = false;
                    break;
                }
                input = input / 10;
            }

            if (isSpecial)
            {
                Console.WriteLine($"{number} is special");
            }
            else
            {
                Console.WriteLine($"{number} is not special");
            }
        }
    }
}
