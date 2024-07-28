namespace GenericAdapter;


public interface IInteger
{
    int Value { get; }
}

public static class Dimension
{
    public class Two : IInteger
    {
        public int Value => 2;
    }

    public class Three : IInteger
    {
        public int Value => 3;
    }
}

public class Vector<T,D> where D : IInteger, new()
{
    protected T[] data;
    public Vector()
    {
        data = new T[new D().Value];
    }
    public T this[int index]
    {
        get => data[index];
        set => data[index] = value;
    }
}

public class Vector2i : Vector<int,Dimension.Two>
{

} 