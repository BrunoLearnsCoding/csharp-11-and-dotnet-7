namespace Delegates_and_Events;

class Program
{
    static void Main(string[] args)
    {
        var harry = new Person("Harry");
        harry.Shout += Harry_Shout;
        harry.Shout += Harry_Shout2;
        harry.Poke();
        harry.Poke();
        harry.Poke();
        harry.Poke();

    }

    static void Harry_Shout(object? sender, EventArgs eventArgs)
    {
        if (sender is null) return;
        var harry = sender as Person;
        if (harry is Person)
        {
            WriteLine("Harry's too angry. Do not poke him anymore.");
        }

    }
        static void Harry_Shout2(object? sender, EventArgs eventArgs)
    {
        if (sender is null) return;
        var harry = sender as Person;
        if (harry is Person)
        {
            WriteLine("Stop it!");
        }

    }

}
