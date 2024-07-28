namespace CopyUsingConstructor;

public class LaptopPrototype
{
    private readonly string _name, _processor;
    private readonly DiskPrototype _disk;

    public LaptopPrototype(string name, string processor, DiskPrototype disk)
    {
        _name = name;
        _processor = processor;
        _disk = disk;
    }

    public LaptopPrototype(LaptopPrototype laptopPrototype)
    {
        _name = laptopPrototype.Name;
        _processor = laptopPrototype.Processor;
        _disk = laptopPrototype.Disk;
    }

    public string Name => _name;
    public string Processor => _processor;
    public DiskPrototype Disk => _disk;
}

public class DiskPrototype
{
    private string _name;
    private readonly int _capacity;

    public DiskPrototype(string name, int capacity)
    {
        _name = name;
        _capacity = capacity;
    }

    public DiskPrototype(DiskPrototype disk)
    {
        _name = disk.Name;
        _capacity = disk.Capacity;
    }

    public string Name => _name;
    public int Capacity => _capacity;
}
