using System.Drawing;

namespace SOLIDPrinciple.OpenClosePrinciple;

/// <summary>
/// Here we are violating Open-Close Principle as we are adding new filter as new requirement is coming.
/// </summary>
public class ProductFilters
{
    public IEnumerable<Product> FilterBySize(IEnumerable<Product> list, Size size)
    {
        return list.Where(x => x.Size == size);
    }

    public IEnumerable<Product> FilterByColor(IEnumerable<Product> list, Color color)
    {
        return list.Where(x => x.Color == color);
    }

    public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> list, Size size, Color color)
    {
        return list.Where(x => x.Size == size && x.Color == color);
    }
}
