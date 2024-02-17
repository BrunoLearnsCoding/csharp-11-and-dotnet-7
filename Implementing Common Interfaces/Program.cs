


namespace Implementing_Common_Interfaces;

class Program
{
    static void Main(string[] args)
    {
        // TestIComparable();
        TestIFormatable();
    }

    private static void TestIFormatable()
    {
        var p = new Person("Wiesley") {FirstName = "Ronald"};
        System.Console.WriteLine(p.ToString("LL, FF", null));
    }

    private static void TestIComparable()
    {
        List<Person> people = new List<Person>();
        foreach (var p in GetPeopleInfo())
        {
            people.Add(new(p.FirstName, p.LastName));
        }
        people.Add(new("Anderson"));

        SortPeople(people);
        PrintOut(people);
    }

    private static void SortPeople(List<Person> people)
    {
        people.Sort();

    }

    private static void PrintOut(List<Person> people)
    {
        foreach (var person in people)
        {
            var fullName = person.LastName + (string.IsNullOrEmpty(person.FirstName)?string.Empty:$", {person.FirstName}");
            System.Console.WriteLine(fullName);
        }
    }

    private record PersonInfo(string FirstName, string LastName);


    private static List<PersonInfo> GetPeopleInfo()
    {
        var nameArray = new string[100] {
            "Olivia Anderson",
            "Ethan Bennett",
            "Sophia Carter",
            "Jackson Davis",
            "Ava Edwards",
            "Noah Foster",
            "Emma Garcia",
            "Aiden Hernandez",
            "Isabella Ingram",
            "Lucas Johnson",
            "Mia King",
            "Liam Lee",
            "Harper Martinez",
            "Elijah Nelson",
            "Abigail Owens",
            "James Parker",
            "Grace Quinn",
            "Benjamin Rodriguez",
            "Scarlett Smith",
            "Alexander Taylor",
            "Chloe Turner",
            "Daniel White",
            "Lily Williams",
            "Henry Young",
            "Addison Adams",
            "Samuel Brown",
            "Zoey Clark",
            "Christopher Davis",
            "Ella Evans",
            "Victoria Fisher",
            "Caleb Green",
            "Penelope Hall",
            "Michael Hughes",
            "Nora Jackson",
            "Sebastian Kelly",
            "Hazel Lewis",
            "David Miller",
            "Scarlett Murphy",
            "Emily Nguyen",
            "Owen Olson",
            "Ava Patel",
            "Noah Reed",
            "Sofia Rivera",
            "Lucas Scott",
            "Olivia Thomas",
            "Emma Turner",
            "Mason Walker",
            "Amelia White",
            "Gabriel Wright",
            "Madison Allen",
            "Isaac Baker",
            "Grace Carter",
            "Logan Davis",
            "Zoe Evans",
            "Carter Fisher",
            "Riley Green",
            "Lily Hill",
            "Ethan Ingram",
            "Chloe Jenkins",
            "Aiden King",
            "Ella Lee",
            "Liam Martinez",
            "Harper Nelson",
            "Jackson Owens",
            "Isabella Parker",
            "Mia Quinn",
            "Noah Rodriguez",
            "Ava Scott",
            "Sophia Taylor",
            "Benjamin Turner",
            "Oliver Walker",
            "Abigail Young",
            "Elijah Adams",
            "Scarlett Bennett",
            "Samuel Brown",
            "Victoria Clark",
            "Caleb Davis",
            "Zoey Evans",
            "Daniel Foster",
            "Grace Garcia",
            "Henry Hughes",
            "Addison Ingram",
            "Christopher Johnson",
            "Nora Kelly",
            "Sebastian Lewis",
            "Hazel Miller",
            "David Murphy",
            "Emily Nguyen",
            "Owen Patel",
            "Ava Reed",
            "Noah Rivera",
            "Emma Smith",
            "Lucas Thomas",
            "Lily Walker",
            "Alexander White",
            "Chloe Wright",
            "Daniel Young",
            "Isabella Allen",
            "Benjamin Baker",
            "Sophia Carter",
        };
        List<PersonInfo> output = new List<PersonInfo>();
        foreach (var element in nameArray)
        {
            var names = element.Split(' ');
            var firstName = names[0];
            var lasttName = names[1];
            output.Add(new PersonInfo(firstName, lasttName));
        }
        return output;
    }
}
