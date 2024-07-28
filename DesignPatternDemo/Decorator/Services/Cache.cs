using Decorator.Interfaces;

namespace Decorator.Services;

public class Cache<TKey, TData> : ICache<TKey, TData> where TData : new() where TKey : notnull
{
    private readonly Dictionary<TKey, TData> _data;

    public Cache()
    {
        _data = new();
    }
    public TData Get(TKey key)
    {
        if (_data.ContainsKey(key))
        {
            return _data[key];
        }
        return new TData();
    }

    public bool Set(TKey key, TData value)
    {
        _data.Add(key, value);
        return true;
    }
}
