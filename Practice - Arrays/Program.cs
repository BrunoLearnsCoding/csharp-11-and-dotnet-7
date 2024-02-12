string[] name = {"George", "Bob", "Sue"};
int choice;

while(true) {
    System.Console.Write("Choose a number betwwen 1 and 3: ");
    if (int.TryParse(Console.ReadLine(), out choice) && (choice >= 1 & choice <= 3)) {
        break;
    }
    System.Console.WriteLine("Invaild input!");
}

System.Console.WriteLine(name[choice-1]);
