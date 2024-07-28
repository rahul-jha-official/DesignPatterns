using Adapter;

namespace VectorRasterAdapter;

public interface ILineToPointAdapter
{
    IEnumerable<Coordinate> GenerateCoordinates(Line line);
}

public class LineToPointCachedAdapter : ILineToPointAdapter
{
    private readonly Dictionary<int, IEnumerable<Coordinate>> _cache;
    private readonly ILineToPointAdapter _adapter;
    public LineToPointCachedAdapter(ILineToPointAdapter adapter)
    {
        _cache = new Dictionary<int, IEnumerable<Coordinate>>();
        _adapter = adapter;
    }

    public IEnumerable<Coordinate> GenerateCoordinates(Line line)
    {
        if (!_cache.ContainsKey(line.GetHashCode()))
        {
            _cache.Add(line.GetHashCode(), _adapter.GenerateCoordinates(line));
        }

        return _cache[line.GetHashCode()];
    }
}
public class LineToPointAdapter : ILineToPointAdapter
{
    public IEnumerable<Coordinate> GenerateCoordinates(Line line)
    {
        Console.Write($"{Environment.NewLine}Generating Coordinates for line [{line.Start.X}, {line.Start.Y}]-[{line.End.X}, {line.End.Y}]{Environment.NewLine}");

        int left = Math.Min(line.Start.X, line.End.X);
        int right = Math.Max(line.Start.X, line.End.X);
        int bottom = Math.Min(line.Start.Y, line.End.Y);
        int top = Math.Max(line.Start.Y, line.End.Y);

        int dx = right - left;
        int dy = bottom - top;

        var coordinates = new List<Coordinate>();

        if (dx == 0)
        {
            if (bottom > top)
            {
                for (int y = top; y <= bottom; y++)
                {
                    coordinates.Add(new Coordinate(left, y));
                }
            }
            else
            {
                for (int y = top; y >= bottom; y--)
                {
                    coordinates.Add(new Coordinate(left, y));
                }
            }
        }

        if (dy == 0)
        {
            if (right > left)
            {
                for (int x = left; x <= right; x++)
                {
                    coordinates.Add(new Coordinate(x, top));
                }
            }
            else
            {
                for (int x = left; x >= right; x--)
                {
                    coordinates.Add(new Coordinate(x, top));
                }
            }
        }

        return coordinates;
    }
}

public interface IDrawPixel
{
    void Draw(Coordinate coordinate);
}
public class DrawPixel : IDrawPixel
{
    public void Draw(Coordinate coordinate)
    {
        Console.Write(coordinate);
    }
}