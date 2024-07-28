using Newtonsoft.Json;

namespace FluentBuilderWithRecursiveGenerics;

public enum Position
{
    Analyst,
    HR,
    Developer,
    Manager
}
public class Person
{
    public string Name;
    public Position Position;
    public DateOnly DOB;

    public class Builder : DOBBuilder<Builder>
    {
        internal Builder() { }
    }

    public static Builder Create => new Builder();

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public abstract class PersonBuilder
{
    protected Person person = new Person();
    public Person Build()
    {
        return person;
    }
}

public class InfoBuilder<T> : PersonBuilder where T : InfoBuilder<T>
{
    public T Named(string name)
    {
        person.Name = name;
        return (T)this;
    }
}

public class ProfileBuilder<T> : InfoBuilder<ProfileBuilder<T>> where T : ProfileBuilder<T>
{
    public T WorksAsA(Position position)
    {
        person.Position = position;
        return (T)this;
    }
}

public class DOBBuilder<T> : ProfileBuilder<DOBBuilder<T>> where T : DOBBuilder<T>
{
    public T BornOn(DateOnly date)
    {
        person.DOB = date;
        return (T)this;
    }
}