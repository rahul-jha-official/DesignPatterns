namespace SOLIDPrinciples.OpenClosePrinciple;

/// <summary>
/// Here we are violating Open-Close Principle as we are adding new filter as new requirement is coming.
/// </summary>
public class ProductWithoutOCPFilter
{
    public IEnumerable<Product> FilterBySize(IEnumerable<Product> list, Size size)
    {
        return list.Where(x => x.ProductSize == size);
    }

    public IEnumerable<Product> FilterByColor(IEnumerable<Product> list, Color color)
    {
        return list.Where(x => x.ProductColor == color);
    }

    public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> list, Size size, Color color)
    {
        return list.Where(x => x.ProductSize == size && x.ProductColor == color);
    }
}
