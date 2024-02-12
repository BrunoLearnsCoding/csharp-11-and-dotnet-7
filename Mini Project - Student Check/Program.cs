string? name = string.Empty;
byte age;

System.Console.Write("What is your name? ");
name = Console.ReadLine();

while (true) {
    Console.Write("How old are you? ");
    bool isValidAge = byte.TryParse(Console.ReadLine(), out age);
    if (isValidAge) break;
    System.Console.WriteLine("Enter a valid age please.");
}

if (name!.ToLower() == "sue" | name.ToLower() == "bob") {
    Console.WriteLine("Hello Professor!");
}
else if (age < 21) {
    Console.WriteLine($"You have to wait {21 - age} year(s) to start this class.");
}
else {
    System.Console.WriteLine($"Hello {name}");
}
