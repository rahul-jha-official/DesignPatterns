namespace SOLIDPrinciples.LiskovSubstitutionPrinciple;

public class Rectangle
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle()
    {
        
    }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int Area()
    {
        return Width * Height;
    }

    public override string? ToString()
    {
        return $"Width: {Width}, Height: {Height}";
    }
}

public class Square : Rectangle
{
    public new int Width
    {
        set { base.Width = base.Height =  value; }
    }

    public new int Height
    {
        set { base.Height = base.Width = value; }
    }
}
