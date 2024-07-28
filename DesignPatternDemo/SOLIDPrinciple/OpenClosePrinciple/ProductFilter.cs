namespace SOLIDPrinciple.OpenClosePrinciple;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T item);
}

public interface IFilter<T>
{
    IEnumerable<T> Filter(IEnumerable<T> products, ISpecification<T> specification);
}

public class ColorSpecification : ISpecification<Product>
{
    private readonly Color _color;
    public ColorSpecification(Color color)
    {
        _color = color;
    }

    public bool IsSatisfiedBy(Product product)
    {
        return product.Color.Equals(_color);
    }
}

public class SizeSpecification : ISpecification<Product>
{
    private readonly Size _size;
    public SizeSpecification(Size size)
    {
        _size = size;
    }

    public bool IsSatisfiedBy(Product product)
    {
        return product.Size.Equals(_size);
    }
}

public class Specifications : ISpecification<Product>
{
    private readonly ISpecification<Product>[] _specifications;
    public Specifications(params ISpecification<Product>[] specifications)
    {
        _specifications = specifications;
    }

    public bool IsSatisfiedBy(Product item)
    {
        foreach (var specification in _specifications)
        {
            if (!specification.IsSatisfiedBy(item))
            {
                return false;
            }
        }
        return true;
    }
}


public class ProductFilter : IFilter<Product>
{
    public IEnumerable<Product> Filter(IEnumerable<Product> products, ISpecification<Product> specification)
    {
        return products.Where(specification.IsSatisfiedBy);
    }
}
