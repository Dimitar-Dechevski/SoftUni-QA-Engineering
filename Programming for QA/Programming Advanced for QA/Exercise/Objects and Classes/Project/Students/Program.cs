namespace Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> listOfStudents = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstName = tokens[0];
                string lastName = tokens[1];
                double grade = double.Parse(tokens[2]);

                Student student = new Student(firstName, lastName, grade);
                listOfStudents.Add(student);
            }

            listOfStudents = listOfStudents.OrderByDescending(s => s.Grade).ToList();


            foreach (Student student in listOfStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:F2}");
            }

        }
    }
}
