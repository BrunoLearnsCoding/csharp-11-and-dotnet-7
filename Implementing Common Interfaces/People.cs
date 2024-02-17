namespace Implementing_Common_Interfaces;

using System.Collections;

public class People : IEnumerable<Person>
{
    List<Person> _people = new List<Person>();
    public IEnumerator<Person> GetEnumerator()
    {
        return _people.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
