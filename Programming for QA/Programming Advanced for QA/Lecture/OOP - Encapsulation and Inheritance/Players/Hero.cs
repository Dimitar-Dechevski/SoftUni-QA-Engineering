namespace Players;

public class Hero
{
    private string username;
    private int level;

    public string Username { get; set; }
    public int Level { get; set; }

    public Hero(string username, int level)
    {
        Username = username;
        Level = level;
    }

    public override string ToString()
    {
        return $"Type: {GetType().Name} Username: {Username} Level: {Level}";
    }

}
