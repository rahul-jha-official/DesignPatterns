namespace SOLIDPrinciples.InterfaceSegregationPrinciple;

/// <summary>
/// Here MultiPurposeDevice implement all the interfaces. We can also combine the interface by creating new interface from all 3.
/// </summary>
public interface IPrinter
{
    void Print(Document d);
}

public interface IScanner
{
    void Scan(Document d);
}

public interface IFaxer
{
    void Fax(Document d);
}

public class MultiPurposeDevice : IPrinter, IScanner, IFaxer
{
    public void Fax(Document d)
    {
        throw new NotImplementedException();
    }

    public void Print(Document d)
    {
        throw new NotImplementedException();
    }

    public void Scan(Document d)
    {
        throw new NotImplementedException();
    }
}

public class Printer : IPrinter
{
    public void Print(Document d)
    {
        throw new NotImplementedException();
    }
}