// See https://aka.ms/new-console-template for more information
using OOPClassLib;

Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
Person hamid = new Person(firstName: "Shahryar", lastName:"Hasani", dateOfBirth: new(1980,11,16));

System.Console.WriteLine(hamid.WorkingDays);
System.Console.WriteLine((byte)hamid.WorkingDays);
System.Console.WriteLine($"Hamid is born on {hamid.DateOfBirth:dddd} {hamid.DateOfBirth:dd-MM-yyyy} and lives currently on the {hamid.HomePlanet}");
if (hamid.WorkingDays.HasFlag(DaysOfWeek.Saturday)) {
    System.Console.WriteLine($"hamid works on {DaysOfWeek.Saturday}");
}

System.Console.WriteLine(hamid.Age);

