using Newtonsoft.Json;

namespace FunctionalBuilder;

public enum Designation
{
    Developer,
    Manager,
    Staff
}
public class Employee
{
    public string Name;
    public Designation Position;

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public sealed class EmployeeBuilder
{
    private readonly List<Action<Employee>> _actions;

    public EmployeeBuilder()
    {
        _actions = new List<Action<Employee>>();
    }

    public void AddAction(Action<Employee> action)
    {
        _actions.Add(action);
    }
    public EmployeeBuilder Called(string name)
    {
        _actions.Add(p => p.Name = name);
        return this;
    }

    public Employee Build()
    {
        var e = new Employee();
        _actions.ForEach(a => a(e));
        return e;
    }
}

public static class EmployeeBuilderExtension
{
    public static EmployeeBuilder WorkAs(this EmployeeBuilder builder, Designation designation)
    {
        builder.AddAction(e => e.Position = designation);
        return builder;
    }
}