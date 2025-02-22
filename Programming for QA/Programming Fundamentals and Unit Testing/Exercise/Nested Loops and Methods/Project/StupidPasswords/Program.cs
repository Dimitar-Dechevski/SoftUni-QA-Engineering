namespace StupidPasswords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 2; i <= n; i += 2)
            {
                for (int j = 1; j <= n; j += 2)
                {
                    int firstPart = i;
                    int secondPart = j;
                    int thirdPart = i * j;
                    Console.Write($"{firstPart}{secondPart}{thirdPart} ");
                }
            }
        }
    }
}
