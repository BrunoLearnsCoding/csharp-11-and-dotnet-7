using OOPClassLib.StudentGrading;
namespace Practice___Student_Grading_System;


class Program
{
    static void Main(string[] args)
    {
        var system = new StudentGradingSystem();
        system.AddStudent(("Bob", 18));
        system.AddStudent(("Tedd", 14));
        system.AddStudent(("Rose", 19));
        system.AddStudent(("Mary", 16));
        system.AddStudent(("Nedd", 16));
        system.AddStudent(("Fred", 18));
        PrintStudents(system.Students);
        system.RemoveStudent("Mary");
        PrintStudents(system.Students);
        // var s = (IList<Student>) system.Students;            // This throws an unhandeled exceptions because the collection is readonly
        // s.RemoveAt(1);
        PrintStudents(system.Students);

    }

    private static void PrintStudents(IEnumerable<Student> students)
    {
        foreach (var student in students)
        {
            System.Console.WriteLine($"{student.Name} {student.Grade}");
        }
    }
}
