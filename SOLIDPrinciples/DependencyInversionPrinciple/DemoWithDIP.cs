namespace SOLIDPrinciples.DependencyInversionPrinciple;

/// <summary>
/// Here MyResearch is depend on Abstraction(IRelationshipBrowser).
/// </summary>
public interface IRelationshipBrowser
{
    IEnumerable<Person> GetAllPersons();
    IEnumerable<Person> GetAllChildrenOfPerson(string name);
}

public class MyRelationships : IRelationshipBrowser
{
    private List<(Person, Relation, Person)> relations;

    public MyRelationships()
    {
        relations = new List<(Person, Relation, Person)>();
    }

    public void AddParentChild(Person p, Person c)
    {
        relations.Add((p, Relation.Father, c));
        relations.Add((p, Relation.Parent, c));
        relations.Add((c, Relation.Child, c));
    }

    public IEnumerable<Person> GetAllChildrenOfPerson(string name)
    {
        var childs = new HashSet<Person>();
        foreach (var person in relations.Where(x => x.Item1.Name.Equals(name) && x.Item2 == Relation.Parent))
        {
            childs.Add(person.Item3);
        }
        return childs;
    }

    public IEnumerable<Person> GetAllPersons()
    {
        var people = new HashSet<Person>();
        foreach (var person in relations)
        {
            people.Add(person.Item1);
        }
        return people;
    }
}

public class MyResearch
{
    public MyResearch()
    {
        
    }

    public void Population(IRelationshipBrowser rb)
    {
        var all = rb.GetAllPersons();
        Console.WriteLine($"Population: {all.Count()}");
        Console.WriteLine($"Names: ({string.Join(',', all.Select(x => x.Name))})");
    }

    public void PersonChilren(IRelationshipBrowser rb, string name)
    {
        var all = rb.GetAllChildrenOfPerson(name);
        Console.WriteLine($"{name} has {all.Count()} Childrens.");
        Console.WriteLine($"Children: ({string.Join(',', all.Select(x => x.Name))})");
    }
}

public class DemoWithDIP
{
    public static void Main(string[] args)
    {
        Person person = new Person(1, "John");
        Person child1 = new Person(2, "Martha");
        Person child2 = new Person(3, "Chris");

        var relationships = new MyRelationships();
        relationships.AddParentChild(person, child1);
        relationships.AddParentChild(person, child2);

        var research = new MyResearch();

        research.Population(relationships);
        research.PersonChilren(relationships, "John");
    }
}
