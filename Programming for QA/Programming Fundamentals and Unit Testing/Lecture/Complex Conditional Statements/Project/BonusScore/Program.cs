namespace BonusScore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number >= 0 && number <= 3)
            {
                number += 5;
                Console.WriteLine(number);
            }
            else if (number >= 4 && number <= 6)
            {
                number += 15;
                Console.WriteLine(number);
            }
            else if (number >= 7 && number <= 9)
            {
                number += 20;
                Console.WriteLine(number);
            }
        }
    }
}
