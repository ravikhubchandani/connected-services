namespace Core.Models;

public class Animal
{
    public int Id { get; init; }
    public string Name { get; init; }

    public Animal(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"{Name} wants water @ {DateTime.Now:HH:mm:ss}";
    }
}
