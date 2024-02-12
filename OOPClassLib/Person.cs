using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace OOPClassLib;

public class Person
{
    private string? _firstName;
    private string? _lastName;
    private DateOnly _dateOfBirth;

    public DateOnly DateOfBirth => _dateOfBirth;
    public DaysOfWeek WorkingDays { get; set; }
    public List<Person> Children = new();
    public readonly string? HomePlanet = "Earth";
    public int Age => DateTime.Now.Year - DateOfBirth.Year;

    [SetsRequiredMembers]
    public Person(string firstName, string lastName, DateOnly dateOfBirth) {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)) {
            throw new ArgumentException("First name and last name shouln't be blank.");
        }
        _firstName = firstName;
        _lastName = lastName;

        _dateOfBirth = dateOfBirth;

    }

}
