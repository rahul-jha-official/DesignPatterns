using System.Text.Json;

namespace CopyUsingExtension;

public static class PrototypeExtension
{
    public static T DeepCopyExtension<T>(this T type) where T : class
    {
        var serialized = JsonSerializer.Serialize(type);
        var deserialize = JsonSerializer.Deserialize<T>(serialized)!;
        return deserialize;
    }
}

public class TablePrototype
{
    private string _brand;
    private MaterialPrototype _material;

    public TablePrototype(string brand, MaterialPrototype material)
    {
        _brand = brand;
        _material = material;
    }

    public string Brand
    {
        get => _brand;
        set => _brand = value;
    }

    public MaterialPrototype Material
    {
        get => _material;
        set => _material = value;
    }
}

public class MaterialPrototype
{
    private WoodType _type;
    private int _width, _height;

    public MaterialPrototype(WoodType type, int width, int height)
    {
        _type = type;
        _width = width;
        _height = height;
    }

    public WoodType Type
    {
        get => _type;
        set => _type = value;
    }

    public int Width
    {
        get => _width;
        set => _width = value;
    }

    public int Height
    {
        get => _height;
        set => _height = value;
    }
}

public enum WoodType
{
    Oak,
    Rosewood,
    Walnut
}