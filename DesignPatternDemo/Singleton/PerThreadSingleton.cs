namespace PerThreadSingleton;

public class ThreaderObject
{
    private static ThreadLocal<ThreaderObject> instance = new(() => new ThreaderObject());
    public static ThreaderObject Instance => instance.Value;

    public int Id;
    private ThreaderObject()
    {
        Id = Thread.CurrentThread.ManagedThreadId;
    }
}