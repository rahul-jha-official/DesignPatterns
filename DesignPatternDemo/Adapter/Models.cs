using System.Collections.ObjectModel;

namespace Adapter;

public class Coordinate
{
    public int X;
    public int Y;

    public Coordinate(int x, int y)
    {
        X = x; 
        Y = y;
    }

    public override string ToString()
    {
        return $"({X},{Y})";
    }
}

public class Line
{
    public Coordinate Start;
    public Coordinate End;

    public Line(Coordinate start, Coordinate end)
    {
        Start = start;
        End = end;
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public class VectorObject : Collection<Line> { }

public class  VectorRectangle : VectorObject
{
    public VectorRectangle(int startX, int startY, int width, int height)
    {
        //Init Lines
        var line1 = new Line(new Coordinate(startX,startY), new Coordinate(startX + width, startY));
        var line2 = new Line(new Coordinate(startX + width, startY), new Coordinate(startX + width, startY + height));
        var line3 = new Line(new Coordinate(startX + width, startY + height), new Coordinate(startX, startY + height));
        var line4 = new Line(new Coordinate(startX, startY + height), new Coordinate(startX, startY));
        
        //Add Lines
        Add(line1);
        Add(line2);
        Add(line3);
        Add(line4);
    }
}