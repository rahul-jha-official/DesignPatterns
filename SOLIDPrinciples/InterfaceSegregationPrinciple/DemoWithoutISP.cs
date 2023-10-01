namespace SOLIDPrinciples.InterfaceSegregationPrinciple;


/// <summary>
/// Here IMachine can be good fit for MultiFunctionDevice but not for OldFunctionDevice. Thus we should break the interface into smaller interface.
/// </summary>
public interface IMachine
{
    void Fax(Document d);
    void Print(Document d);
    void Scan(Document d);
}

public class MultiFunctionDevice : IMachine
{
    public void Fax(Document d)
    {
        //Body For Fax
    }

    public void Print(Document d)
    {
        //Body For Print
    }

    public void Scan(Document d)
    {
        //Body For Scan
    }
}

public class OldFunctionDevice : IMachine
{
    public void Fax(Document d)
    {
        //Can't Fax
        throw new NotImplementedException();
    }

    public void Print(Document d)
    {
        //Body for Print
    }

    public void Scan(Document d)
    {
        //Can't Scan
        throw new NotImplementedException();
    }
}
