namespace Disposing_unmanaged_resources;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public class ObjectWithUnmanagedResource : IDisposable
{
    // Finalizer aka deconstructor
    ~ObjectWithUnmanagedResource() {

    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
