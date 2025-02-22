namespace NumberOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            char mathOperator = char.Parse(Console.ReadLine());
            double result = 0;

            if (mathOperator.Equals('+'))
            {
                result = firstNumber + secondNumber;
            }
            else if (mathOperator.Equals('-'))
            {
                result = firstNumber - secondNumber;
            }
            else if (mathOperator.Equals('*'))
            {
                result = firstNumber * secondNumber;
            }
            else if (mathOperator.Equals('/'))
            {
                result = firstNumber / secondNumber;
            }

            Console.WriteLine($"{firstNumber} {mathOperator} {secondNumber} = {result:F2}");

        }
    }
}
