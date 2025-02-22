namespace Aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentageOfOccupiedSpace = double.Parse(Console.ReadLine());

            double volumeOfAquarium = length * width * height;
            double volumeInLiters = volumeOfAquarium / 1000;
            double emptySpace = 1 - (percentageOfOccupiedSpace / 100);
            double neededWater = volumeInLiters * emptySpace;

            Console.WriteLine($"{neededWater:F2}");
        }
    }
}
