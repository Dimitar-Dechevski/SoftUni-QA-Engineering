namespace Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> listOfSongs = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split("_", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string typeList = tokens[0];
                string name = tokens[1];
                string time = tokens[2];

                Song song = new Song(typeList, name, time);
                listOfSongs.Add(song);
            }

            string playlist = Console.ReadLine();

            foreach (Song song in listOfSongs)
            {
                if (playlist.Equals(song.TypeList))
                {
                    Console.WriteLine(song.Name);
                }
                else if (playlist.Equals("all"))
                {
                    Console.WriteLine(song.Name);
                }
            }

        }
    }
}
