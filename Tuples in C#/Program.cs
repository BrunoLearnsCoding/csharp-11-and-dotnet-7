namespace Tuples_in_C_;

class Program
{
    static void Main(string[] args)
    {
        (int Grade, string Name) type;

        var r = (Grade:15, Name:"George");
        System.Console.WriteLine(r);
        (int, string) p;
        p = (14, "Joe");
        var o = GetTuple();
        System.Console.WriteLine(o.Name);
        System.Console.WriteLine(o.Grade);


    }
    static (int Grade, string Name) GetTuple() {
        return (19, "Paul");
    }
}

public class MyClass {
    public int Grade;
    public string? Name;
}

