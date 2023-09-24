namespace SOLIDPrinciples.SingleResponsibilityPrinciple;
/// <summary>
/// Here, 
/// Journal class having single responsibility of updating journal
/// Persistence class having responsibility of saving journal to file.
/// </summary>
public class Journal
{
    private readonly IList<string> entries;

    public Journal()
    {
        entries = new List<string>();
    }

    public void Add(string entry)
    {
        entries.Add(entry);
    }

    public void Remove(int index)
    {
        entries.RemoveAt(index);
    }

    public override string? ToString()
    {
        return string.Join(Environment.NewLine, entries.Select((e, i) => $"{(i + 1)}\t{e}"));
    }
}

public class Persistence
{
    public void Save(Journal journal, string filename, bool overwrite = false)
    {
        if (overwrite || !File.Exists(filename))
        {
            File.WriteAllText(filename, journal.ToString());
        }
    }
}
