namespace SOLIDPrinciples.OpenClosePrinciple;


/// <summary>
/// Here Product Filter is Open for any new filter which will be implementing ISpecification.
/// ProductFilter is closed for any modification.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ISpecification<T>
{
    bool IsSatisfied(T entity);
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
    public bool IsSatisfied(Product entity)
    {
        return entity.ProductColor == _color;
    }
}

public class SizeSpecification : ISpecification<Product>
{
    private readonly Size _size;
    public SizeSpecification(Size size)
    {
        _size = size;
    }
    public bool IsSatisfied(Product entity)
    {
        return entity.ProductSize == _size;
    }
}

public class AndSpecification : ISpecification<Product>
{
    private readonly ISpecification<Product> _firstSpecification, _secondSpecification;

    public AndSpecification(ISpecification<Product> firstSpecification, ISpecification<Product>  secondSpecification)
    {
        _firstSpecification = firstSpecification;
        _secondSpecification = secondSpecification;
    }
    public bool IsSatisfied(Product entity)
    {
        return _firstSpecification.IsSatisfied(entity) && _secondSpecification.IsSatisfied(entity);
    }
}

public class ProductFilter : IFilter<Product>
{
    public IEnumerable<Product> Filter(IEnumerable<Product> products, ISpecification<Product> specification)
    {
        return products.Where(product => specification.IsSatisfied(product));
    }
}
