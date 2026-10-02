public sealed class Student : IHasId
{
    public Student(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; }
    public string Name { get; }

    public override string ToString()
    {
        return $"{Id}: {Name}";
    }
}
