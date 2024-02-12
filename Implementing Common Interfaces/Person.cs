namespace Implementing_Common_Interfaces;

public class Person : IComparable<Person>{
    public string? FirstName { get; set; }
    public string LastName { get; set; }

    public Person(string lastName)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(lastName);
        LastName = lastName;        
    }
    public Person(string firstName, string lastName) : this(lastName) {
        FirstName = firstName;
    }

    public int CompareTo(Person? other)
    {
        if (other is null) return -1;
        return $"{LastName}{FirstName}".ToLower().CompareTo($"{other.LastName}{other.FirstName}".ToLower());

    }
}