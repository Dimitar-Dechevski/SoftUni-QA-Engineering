namespace StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(name))
                {
                    students[name].Add(grade);
                }
                else
                {
                    students.Add(name, new List<double>());
                    students[name].Add(grade);
                }
            }

            foreach (KeyValuePair<string, List<double>> entry in students)
            {
                double average = entry.Value.Average();

                if (average >= 4.50)
                {
                    Console.WriteLine($"{entry.Key} -> {average:F2}");
                }

            }

        }
    }
}
