namespace CopyUsingCustomInterface;

public interface IPrototype<T>
{
    T DeepCopy();
}

public class MobilePrototype : IPrototype<MobilePrototype>
{
    private readonly string _brand, _name;
    private readonly DisplayPrototype _display;
    public MobilePrototype(string brand, string name, DisplayPrototype displayPrototype)
    {
        _brand = brand;
        _name = name;
        _display = displayPrototype;
    }

    public MobilePrototype DeepCopy()
    {
        return new MobilePrototype(_brand, _name, _display.DeepCopy());
    }
}

public class DisplayPrototype : IPrototype<DisplayPrototype>
{
    private readonly DisplayType _type;
    private readonly int _width, _height;

    public DisplayPrototype(DisplayType type, int width, int height)
    {
        _type = type;
        _width = width;
        _height = height;
    }

    public DisplayPrototype DeepCopy()
    {
        return new DisplayPrototype(_type, _width, _height);
    }
}

public enum DisplayType
{
    LCD,
    IPS,
    LED,
    OLED,
    AMOLED
}