namespace ProductOfThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
            {
                Console.WriteLine("zero");
            }
            else if (firstNumber > 0 && secondNumber > 0 && thirdNumber > 0)
            {
                Console.WriteLine("positive");
            }
            else
            {
                if (firstNumber < 0 && secondNumber < 0
                    || firstNumber < 0 && thirdNumber < 0
                    || secondNumber < 0 && thirdNumber < 0)
                {
                    Console.WriteLine("positive");
                }
                else
                {
                    Console.WriteLine("negative");
                }
            }
        }
    }
}
