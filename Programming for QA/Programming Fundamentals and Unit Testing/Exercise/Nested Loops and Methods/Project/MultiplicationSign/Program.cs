namespace MultiplicationSign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            string output = CheckSign(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine(output);
        }

        static string CheckSign(int firstNumber, int secondNumber, int thirdNumber)
        {
            string sign;
            int counter = 0;

            if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
            {
                sign = "zero";
            }
            else
            {
                if (firstNumber < 0)
                {
                    counter++;
                }
                if (secondNumber < 0)
                {
                    counter++;
                }
                if (thirdNumber < 0)
                {
                    counter++;
                }

                if (counter % 2 == 0)
                {
                    sign = "positive";
                }
                else
                {
                    sign = "negative";
                }
            }

            return sign;
        }

    }
}
