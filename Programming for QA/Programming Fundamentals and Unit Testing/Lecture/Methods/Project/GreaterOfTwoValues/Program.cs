namespace GreaterOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type.Equals("int"))
            {
                int firstValue = int.Parse(Console.ReadLine());
                int secondValue = int.Parse(Console.ReadLine());
                int output = GreaterOfTwoValues(firstValue, secondValue);
                Console.WriteLine(output);
            }
            else if (type.Equals("char"))
            {
                char firstValue = char.Parse(Console.ReadLine());
                char secondValue = char.Parse(Console.ReadLine());
                char output = GreaterOfTwoValues(firstValue, secondValue);
                Console.WriteLine(output);
            }
            else if (type.Equals("string"))
            {
                string firstValue = Console.ReadLine();
                string secondValue = Console.ReadLine();
                string output = GreaterOfTwoValues(firstValue, secondValue);
                Console.WriteLine(output);
            }
        }

        static string GreaterOfTwoValues(string firstValue, string secondValue)
        {
            string output;
            int comparer = firstValue.CompareTo(secondValue);

            if (comparer > 0)
            {
                output = firstValue;
            }
            else
            {
                output = secondValue;
            }
            return output;
        }

        static int GreaterOfTwoValues(int firstValue, int secondValue)
        {
            int output;

            if (firstValue > secondValue)
            {
                output = firstValue;
            }
            else
            {
                output = secondValue;
            }
            return output;
        }

        static char GreaterOfTwoValues(char firstValue, char secondValue)
        {
            char output;

            if (firstValue > secondValue)
            {
                output = firstValue;
            }
            else
            {
                output = secondValue;
            }
            return output;
        }

    }
}
