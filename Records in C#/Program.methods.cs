

namespace Records_in_C_;

// Declaring a record using a primary constructor for the record. In this case, the compiler generates 
// properties for all parameters in the record's primary constructor :
public record Money(string Currency, decimal Value);

// This declaration causes the properties to be immutable.
public record Point(int X, int Y) {
    public int X { get; set; }
    public int Y { get; set; }
}

// In C# 10 you can define a record 
public record DateRange {
    public DateOnly StartDate { get; init; }
    public DateOnly EndDate { get; init; }
    public DateRange(DateOnly startDate, DateOnly endDate) {
        if (endDate < startDate) { throw new ArgumentOutOfRangeException("");}
        StartDate = startDate;
        EndDate = endDate;
    }

}

public class Person : IEquatable<Person> {
    public string? Name { get; set; }
    public DateOnly DateOfBith { get; set; }

    public bool Equals(Person? other)
    {
        if (other is null) return false;
        return (DateOfBith == other.DateOfBith && Name == other.Name);
    }
}

public record Racer(Person Person, string Car);


public record HowShallowImmutabilityWorks(int[] Array);


public partial class Program {
    public void ToBeRefactored() {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("En-US");
        var price = new Money("USD", 500M);
        // price.Value = 550M;                  This statement receives compiler error
        var point = new Point(14,25);
        point.X = 47;                           // Now the record is not IMMUTAVBLE!

        var range1 = new DateRange(new DateOnly(2023,11,5), new DateOnly(2023,11,9));
        System.Console.WriteLine(range1);

        // CAUTION :
        // The 'with statement' uses a mechanism to create a shallow copy of a record which bypasses constructors of the record, 
        // hence preventing validations before instatiating the record.
        // This mechanism is overidable and described in the C# documentaion.

        // As you see below, EndDate COULD be less than start date if you make a copy of range1 using 'with' statement.
        var range2 = range1 with {EndDate = new DateOnly(2022,11,4)};
        System.Console.WriteLine(range2);

        System.Console.WriteLine(range1.StartDate.Equals(range2.StartDate));
        System.Console.WriteLine(range1.EndDate.Equals(range2.EndDate));

        // How shallow immutability works
        
        var h1 = new HowShallowImmutabilityWorks(new int[] {12,16});
        var h2 = new HowShallowImmutabilityWorks(new int[] {48,105});
        System.Console.WriteLine($"h1 hashcode before the change : {h1.GetHashCode()}"); // Outputs -1990191497

        h1.Array[1] = 45;                       // Changes the value of the array item despite of mutability of the property.

        System.Console.WriteLine(h1.Array[1]);  // Outputs 45

        System.Console.WriteLine($"h1 hashcode after the change : {h1.GetHashCode()}"); // Outputs -1990191497
        // This shows that equality doesn't work when the record suffers from shallow immutanbility. 

        // How euality works in records

        Point point11 = new(11,15);
        Point point12 = new(11,15);
        System.Console.WriteLine(point11 == point12); // Outputs True

        DateRange range11 = new(new DateOnly(2022,12,12), new DateOnly(2022,12,15));
        DateRange range12 = new(new DateOnly(2022,12,12), new DateOnly(2022,12,15));

        System.Console.WriteLine(range11 == range12); // Outputs True
        System.Console.WriteLine($"range11.GetHashCode() : {range11.GetHashCode()} | range12.GetHashCode() : {range12.GetHashCode()}");


        DateRange range13 = new(new DateOnly(2022,12,12), new DateOnly(2022,12,19));
        
        System.Console.WriteLine(range11 == range13); // Outputs Flase. Equality works fine :)
        System.Console.WriteLine($"range11.GetHashCode() : {range11.GetHashCode()} | range13.GetHashCode() : {range13.GetHashCode()}");

        // Another example for failing equity
        Person p1 = new Person() {Name = "Behrang", DateOfBith = new DateOnly(1975,7,14)};
        Person p2 = new Person() {Name = "Behrang", DateOfBith = new DateOnly(1975,7,14)};
        Racer racer1 = new(p1, "Ferrari");
        Racer racer2 = new(p2, "Ferrari");
        System.Console.WriteLine($"racer1 == racer2 {racer1 == racer2}");       // Outputs Flase until Person type implements IEquatable<Person>
    }


}

