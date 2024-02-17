using System.Globalization;
using System.Text;

namespace Implementing_Common_Interfaces;

public class Person : IComparable<Person>, IFormattable
{
    public string? FirstName { get; set; }
    public string LastName { get; set; }

    public Person(string lastName)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(lastName);
        LastName = lastName;
    }
    public Person(string firstName, string lastName) : this(lastName)
    {
        FirstName = firstName;
    }

    public int CompareTo(Person? other)
    {
        if (other is null) return -1;
        return $"{LastName}{FirstName}".ToLower().CompareTo($"{other.LastName}{other.FirstName}".ToLower());

    }

    public override string ToString()
    {
        return ToString("G", null);
    }

    public string ToString(string? format) {
        return ToString(format, CultureInfo.CurrentCulture);
    }
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        format = format?.ToUpper();
        if (string.IsNullOrWhiteSpace(format) || format == "G")
        {
            
        }
        var output = new StringBuilder();

        for (int i = 0; i < format?.Length; i++)
        {
            char c = format[i];
            var token = format[i].ToString();

            while ( i + 1 < format.Length && format[i + 1] == c )
            {
                token += c;
                i++;
            }
            switch (token)
            {
                case "F":
                    output.Append(FirstName?.Substring(0, 1));
                    break;
                case "FF":
                    output.Append(FirstName);
                    break;
                case "L":
                    output.Append(LastName.Substring(0, 1));
                    break;
                case "LL":
                    output.Append(LastName);
                    break;
                default:
                    output.Append(token);
                    break;
            }

        }
        return output.ToString();
    }
}