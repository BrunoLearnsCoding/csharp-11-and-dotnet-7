namespace Delegates_and_Events;

public class Person
{

    public event EventHandler? Shout;
    public int AngerLevel {get; private set;}
    public string Name {get; init;}
    public void Poke()
    {
        AngerLevel++;
        if (AngerLevel > 3)
        {
            Shout?.Invoke(this, EventArgs.Empty);
        }

    }

    public Person(string name)
    {
        Name = name;
    }
}
