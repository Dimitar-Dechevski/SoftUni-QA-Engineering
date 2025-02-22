namespace LargestNumOutOf3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());


            if (firstNumber >= secondNumber && firstNumber >= thirdNumber)
            {
                Console.WriteLine(firstNumber);
            }
            else if (secondNumber >= firstNumber && secondNumber >= thirdNumber)
            {
                Console.WriteLine(secondNumber);
            }
            else
            {
                Console.WriteLine(thirdNumber);
            }
        }
    }
}
