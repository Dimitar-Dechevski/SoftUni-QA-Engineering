namespace Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Student> listOfStudents = new List<Student>();

            while (!input.Equals("end"))
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                string homeTown = tokens[3];

                Student student = new Student(firstName, lastName, age, homeTown);
                listOfStudents.Add(student);

                input = Console.ReadLine();
            }

            string town = Console.ReadLine();

            foreach (Student student in listOfStudents)
            {
                if (student.HomeTown.Equals(town))
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }

        }
    }
}
