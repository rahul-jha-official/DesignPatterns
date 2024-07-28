namespace SOLIDPrinciple.OpenClosePrinciple;

public static class ProductsSampleData
{
    public static IEnumerable<Product> Products = new List<Product>()
    {
        new Product("Dragon Ball Printed T Shirt", Color.White, Size.S),
        new Product("Dragon Ball Printed T Shirt", Color.White, Size.M),
        new Product("Dragon Ball Printed T Shirt", Color.Red, Size.L),
        new Product("Dragon Ball Printed T Shirt", Color.Green, Size.XXL),
        new Product("Monkey D Luffy T Shirt", Color.White, Size.M),
        new Product("Monkey D Luffy T Shirt", Color.Black, Size.XS),
        new Product("Monkey D Luffy T Shirt", Color.Blue, Size.XL),
    };
}
