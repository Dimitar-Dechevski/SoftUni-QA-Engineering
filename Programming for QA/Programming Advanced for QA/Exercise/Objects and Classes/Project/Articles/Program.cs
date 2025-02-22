namespace Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string title = tokens[0];
            string content = tokens[1];
            string author = tokens[2];

            Article article = new Article(title, content, author);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                string value = input[1];

                if (command.Equals("Edit"))
                {
                    article.Edit(value);
                }
                else if (command.Equals("ChangeAuthor"))
                {
                    article.ChangeAuthor(value);
                }
                else if (command.Equals("Rename"))
                {
                    article.Rename(value);
                }
            }

            Console.WriteLine(article.ToString());

        }
    }
}
