namespace FirstNNumbersSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            int result = 0;

            for (int i = 1; i <= number; i++)
            {
                result += i;

                if (i == number)
                {
                    Console.Write(i + "=" + result);
                }
                else
                {
                    Console.Write(i + "+");
                }
            }
        }
    }
}
