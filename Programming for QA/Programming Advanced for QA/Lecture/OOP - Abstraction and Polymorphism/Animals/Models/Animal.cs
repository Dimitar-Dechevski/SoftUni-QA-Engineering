namespace Animals.Models;

public abstract class Animal
{
    private string name;
    private string favouriteFood;

    public string Name { get; set; }
    public string FavoriteFood { get; set; }

    public Animal(string name, string favouriteFood)
    {
        Name = name;
        FavoriteFood = favouriteFood;
    }

    public abstract string ExplainSelf();
   
}
