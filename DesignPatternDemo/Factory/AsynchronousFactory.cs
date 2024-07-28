namespace AsynchronousFactory;

public class TestObject
{
    private TestObject()
    {
        
    }

    private async Task<TestObject> InitAsync()
    {
        await Task.Delay(1000);
        return this;
    }

    public static Task<TestObject> Create()
    {
        var ob = new TestObject();
        return ob.InitAsync();
    }
}

