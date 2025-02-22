using Raiding.Contracts;

namespace Raiding.Models;

public abstract class BaseHero : IHero
{
    private string name;
    private int power;

    public string Name { get; }
    public abstract int Power { get; }

    public BaseHero(string name)
    {
        Name = name;
    }

    public virtual string CastAbility()
    {
        return $"{GetType().Name} - {Name}";
    }

}
