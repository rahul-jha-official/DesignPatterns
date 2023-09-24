namespace SOLIDPrinciples.OpenClosePrinciple;

public class Product
{
    public string ProductName { get; set; }
    public Color ProductColor { get; set; }
    public Size ProductSize { get; set; }

    public Product(string name, Color color, Size size)
    {
        ProductName = name;
        ProductColor = color;
        ProductSize = size;
    }

    public override string? ToString()
    {
        return $"(Name: {ProductName}, Color: {ProductColor}, Size: {ProductSize})";
    }
}
