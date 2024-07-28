namespace SOLIDPrinciple.OpenClosePrinciple;

public class Product
{
    public string Name { get; set; }
    public Color Color { get; set; }
    public Size Size { get; set; }

    public Product(string name, Color color, Size size)
    {
        Name = name;
        Color = color;
        Size = size;
    }

    public override string? ToString()
    {
        return $"(Name: {Name}, Color: {Color}, Size: {Size})";
    }
}