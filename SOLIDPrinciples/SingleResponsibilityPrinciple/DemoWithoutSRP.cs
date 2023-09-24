namespace SOLIDPrinciples.SingleResponsibilityPrinciple;

/// <summary>
/// Here we are violating Single Responsibility Principle as we have given too many responsibity to single class.
/// </summary>
public class Journal_WO_SRP
{
    private readonly IList<string> entries;

    public Journal_WO_SRP()
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

    public void Save(string filename, bool overwrite = false)
    {
        if (overwrite || !File.Exists(filename))
        {
            File.WriteAllText(filename, ToString());
        }
    }
}
