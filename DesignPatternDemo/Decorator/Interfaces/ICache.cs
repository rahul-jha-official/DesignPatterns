namespace Decorator.Interfaces;

public interface ICache<TKey,TData>
{
    TData Get(TKey key);
    bool Set(TKey key, TData value);
}
