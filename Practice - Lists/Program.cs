

using System.Collections;

string allStars = "Ross,Chandler,Monica,Phoebe";
List<string> stars = allStars.Split(',').ToList();
stars.Add("Joey");
stars.Add("Rachel");
string[] stuntmasters = {"Sue", "Bob", "Tailor"};
stars.AddRange(stuntmasters);

System.Console.WriteLine("Looping through a list using foreach loop.");
foreach (var star in stars)
{
    System.Console.WriteLine(star);             // List items could be accessed by using foreach loop, which uses IEnumerator
}
System.Console.WriteLine(new string('-',20));
System.Console.WriteLine("Looping through a list using enumerator object.");

IEnumerator enumerator = stars.GetEnumerator();

while (enumerator.MoveNext()) {
    System.Console.WriteLine(enumerator.Current);
}
System.Console.WriteLine(new string('-',20));

System.Console.WriteLine("Looping through a list using array notation and for loop.");
for (int i = 0; i < stars.Count; i++) {         // Count is like Length in arrays. It is NOT zero-based. 
    System.Console.WriteLine(stars[i]);         // List items could be accessed by array notation too.
}
System.Console.WriteLine(new string('-',20));

stars.Remove("Bob");
stars.Remove("Sue");
stars.Remove("Tailor");

System.Console.WriteLine("Looping through the list after removing some non-srats.");
for (int i = 0; i < stars.Count; i++) {         // Count is like Length in arrays. It is NOT zero-based. 
    System.Console.WriteLine(stars[i]);         // List items could be accessed by array notation too.
}
System.Console.WriteLine(new string('-',20));





