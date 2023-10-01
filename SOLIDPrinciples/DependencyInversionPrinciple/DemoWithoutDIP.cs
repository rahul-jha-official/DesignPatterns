namespace SOLIDPrinciples.DependencyInversionPrinciple;

/// <summary>
/// Here Research is dependent on Relationships class, thus we cannot change the implementaion architecture of Relationships.
/// </summary>
public class Relationships
{
    private List<(Person, Relation, Person)> relations;

    public Relationships()
    {
        relations = new List<(Person, Relation, Person)>();
    }

    public void AddParentChild(Person p, Person c)
    {
        relations.Add((p, Relation.Father, c));
        relations.Add((p, Relation.Parent, c));
        relations.Add((c, Relation.Child, c));
    }

    public List<(Person, Relation, Person)> Relations => relations;
}

public class Research
{
    public Research(Relationships relationships)
    {
        var r = relationships.Relations;

        foreach (var rel in r.Where(x => x.Item1.Name == "John" && x.Item2 == Relation.Parent))
        {
            Console.WriteLine($"John has a child called {rel.Item3.Name}");
        }
    }
}
public class DemoWithoutDIP
{
    //public static void Main(string[] args)
    //{
    //    Person person = new Person(1, "John");
    //    Person child1 = new Person(2, "Martha");
    //    Person child2 = new Person(3, "Chris");

    //    Relationships relationships = new Relationships();
    //    relationships.AddParentChild(person, child1);
    //    relationships.AddParentChild(person, child2);

    //    Research research = new Research(relationships);
    //}
}
