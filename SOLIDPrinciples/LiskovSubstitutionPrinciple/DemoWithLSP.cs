namespace SOLIDPrinciples.LiskovSubstitutionPrinciple;

public class Triangle
{
    public virtual int Side1 { get; set; }
    public virtual int Side2 { get; set; }
    public virtual int Side3 { get; set; }

    public Triangle()
    {

    }

    public Triangle(int side1, int side2, int side3)
    {
        Side1 = side1;
        Side2 = side2;
        Side3 = side3;
    }

    public double Area()
    {
        var s = (Side1 + Side2 + Side3) / 2.0;
        return Math.Sqrt(s * (s - Side1) * (s - Side2) * (s - Side3));
    }

    public override string? ToString()
    {
        return $"a: {Side1}, b: {Side2}, c: {Side3}";
    }
}

public class EquilateralTrianle : Triangle
{
    public override int Side1
    {
        set { base.Side1 = base.Side2 = base.Side3 = value; }
    }

    public override int Side2
    {
        set { base.Side2 = base.Side1 = base.Side3 = value; }
    }

    public override int Side3
    {
        set { base.Side3 = base.Side1 = base.Side2 = value; }
    }
}
