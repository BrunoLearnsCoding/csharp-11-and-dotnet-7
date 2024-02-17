namespace Yield_keyword;

class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("The programm starts");
        // See_How_IEnumerable_Works_Without_Yield();
        See_How_IEnumerable_Works_With_Yield();

        System.Console.WriteLine("The program finished.");
    }

    static void See_How_IEnumerable_Works_Without_Yield() {
        var people = DataAccess.GetPeople();
        foreach (var person in people)
        {
            System.Console.WriteLine($"{person.FirstName} {person.LastName}");
        }
    }

    static void See_How_IEnumerable_Works_With_Yield() {
        var people = DataAccess.GetPeopleUsingYield();

        foreach (var person in people)
        {
            System.Console.WriteLine($"{person.FirstName} {person.LastName}");
        }
    }
}
