namespace Factory;

public class Point
{
    public static Point CartesianPoint(double x, double y)
    {
        return new Point(x, y);
    }
    public static Point PolarPoint(double roh, double theeta)
    {
        return new Point(roh * Math.Cos(theeta), roh * Math.Sin(theeta));
    }
    public double X, Y;
    private Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"({X},{Y})";
    }
}