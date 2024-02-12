using System.Diagnostics.CodeAnalysis;

namespace OOPClassLib.StudentGrading;
public class Student
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required int Grade {get; set; }

    private int _inid;
    public int INId
    {
        get { return _inid; }
        set { _inid = value; }
    }
    
       
    
    [SetsRequiredMembers]
    internal Student(string name, int grade) {
        Name = name;
        Grade = grade;
        Id = Guid.NewGuid();
    }
}