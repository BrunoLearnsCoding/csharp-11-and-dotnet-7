
using System.Collections.Generic;

// Instantiating and initializing a Dictionary using an initializor.
var carBrands = new Dictionary<string, string>() {
    ["Merzedes"] = "Germany",
    ["Ferrari"] = "Italy",
    ["Audi"] = "Germany",
    ["Peugoet"] = "France",
    ["Ford"] = "USA"
};


// Console.TreatControlCAsInput = true;

Dictionary<int,string> employees = new Dictionary<int, string>();

employees[101] = "George Trever";
employees[102] = "Jane Polen";
employees[103] = "Paul Zelinskey";
employees[104] = "Natan Arshi";
employees[105] = "Hamed Bahlani";
employees[106] = "Luca Travatoni";

// System.Console.WriteLine(employees[180]);        // employees[choice] can throw an KeyNotFoundExeption if the provided 
                                                    // key is not found in the dictionary   

string? choiceText;
int choice;

while(true) {
    System.Console.Write("Input employee ID [Enter to Exit]: ");
    choiceText = Console.ReadLine();
    if (int.TryParse(choiceText, out choice)) {
    //     try {
    //        System.Console.WriteLine(employees[choice]);
    //     }
    //     catch (KeyNotFoundException) {
    //         System.Console.WriteLine("No such an employee!");    
    //     }
        string? match;
        if (employees.TryGetValue(choice, out match)) {             // You can use .TryGetValue() method instead of catching the 
            System.Console.WriteLine(match);                        // NoKeyFoundExeption as above.
        }
        else {
            System.Console.WriteLine("No such an employee!");
        }
    }
    else if (string.IsNullOrEmpty(choiceText)) {
        break;
    }
}
System.Console.WriteLine("Bye!");