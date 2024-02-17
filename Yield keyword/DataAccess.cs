namespace Yield_keyword;

public class DataAccess
{
    /// <summary>
    /// Returning an IEnumerable without using yield keyword causes to 
    /// all the objects in the IEnumerable to be created at first 
    /// and returned to the calling method. 
    /// </summary>
    /// <returns>
    /// The programm starts
    /// The person Jimmy Bogard initialized.
    /// The person Tim Corey initialized.
    /// The person Soctt Honselman initialized.
    /// Jimmy Bogard
    /// Tim Corey
    /// Soctt Honselman
    /// The program finished.
    /// </returns>
    public static IEnumerable<Person> GetPeople()
    {
        return new List<Person>() {
            new Person("Jimmy","Bogard"),
            new Person("Tim", "Corey"),
            new Person("Soctt", "Honselman")
        };
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns>
    /// The programm starts
    /// The person Jimmy Bogard initialized.
    /// Jimmy Bogard
    /// The person Tim Corey initialized.
    /// Tim Corey
    /// The person Soctt Honselman initialized.
    /// Soctt Honselman
    /// The program finished.
    /// </returns>
    public static IEnumerable<Person> GetPeopleUsingYield()
    {
        yield return new Person("Jimmy","Bogard");
        yield return new Person("Tim", "Corey");
        yield return new Person("Soctt", "Honselman");

    }
}



