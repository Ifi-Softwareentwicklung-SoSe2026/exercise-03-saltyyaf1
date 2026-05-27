using System.Dynamic;

var plants = new List<Plants>
{
    new AppleTree("Boskoop", age: 5),
    new Pumpkin("Hokkaido", age: 1),
    new ChestnutTree("Maroni", age: 12)
};

foreach (var plant in plants)
{
    Console.WriteLine(plant.GetDescription());

    if (plant is ICookable cookable)
    {
        Console.WriteLine($"  -> Kochbar: {cookable.GetCookingSuggestion()}");
    }

    if (plant is IWoodProducer woodProducer)
    {
        Console.WriteLine($"  -> Holz nutzbar: {woodProducer.GetWoodUsage()}");
    }
}
public interface ICookable
{
    public string GetCookingSuggestion();
}
public interface IWoodProducer
{
    public string GetWoodUsage();
}
public abstract class Plants
{
    public string Name { get; }
    public uint Age { get; }

    protected Plants(string name, uint age)
    {
        Name = name;
        Age = age;
    }

    public virtual string GetDescription() => $"{GetType().Name}: {Name}, {Age} Jahre alt";
}

public class AppleTree : Plants, ICookable, IWoodProducer
{
    public AppleTree(string name, uint age) : base(name, age) { }
    public string GetCookingSuggestion()
    {
        return "Apfelstrudel";
    }
    public string GetWoodUsage()
    {
        return "Möbel";
    }
}
public class Pumpkin : Plants
{
    public Pumpkin(string name, uint age) : base(name, age) { }
}
public class ChestnutTree : Plants
{
    public ChestnutTree(string name, uint age) : base(name, age) { }
}