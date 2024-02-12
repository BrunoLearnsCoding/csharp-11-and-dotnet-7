using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace OOPClassLib.StudentGrading;

public class StudentGradingSystem
{
    private readonly List<Student> students = new();
    public void AddStudent((string Name, int Grade) rawData)
    {
        Student newStudent = new(name: rawData.Name, grade: rawData.Grade);
        students.Add(newStudent);
    }
    public IEnumerable<Student> Students => students.AsReadOnly();
    public void RemoveStudent(Guid id)
    {
        var found = students.Find(s => s.Id == id);
        if (found is not null)
        {
            students.Remove(found);
            System.Console.WriteLine($"The student {found.Name} was removed from the grading system.");
        }
    }

    public void RemoveStudent(string name) {
        var found = students.Find(s => s.Name == name);
        if (found is not null) {
            students.Remove(found);
            System.Console.WriteLine($"The student {found.Name} was removed from the grading system.");
        }

    }

    public bool TryRemove(string name, out Student? student) {
        student = students.Find(s => s.Name == name);
        if (student is not null) {
            students.Remove(student);
            System.Console.WriteLine($"The student {student.Name} was removed from the grading system.");
            return true;
        }
        student = null;
        return false;

    }
}

