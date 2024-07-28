namespace Singleton;

public interface IDatebase
{
    int GetPopulation(string name);
}

public class SingletonDatabase : IDatebase
{
    private static Lazy<SingletonDatabase> instance = new(() => new SingletonDatabase());
    
    public static SingletonDatabase Instance()
    {
        return instance.Value;
    }

    private readonly Dictionary<string, int> capitals;
    private SingletonDatabase()
    {
        capitals = SampleData.CityPopulationPair;
    }

    public int GetPopulation(string name)
    {
        return capitals[name];
    }
}
public static class SampleData
{
    public static Dictionary<string,int> CityPopulationPair = new Dictionary<string, int>()
    {
        { "Jhansi", 1 },
        { "Lalitpur", 2 },
        { "Kanpur", 3 },
    };
}
