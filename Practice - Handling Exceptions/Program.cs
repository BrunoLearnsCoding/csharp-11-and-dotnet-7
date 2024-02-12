using CalculatorLib;
namespace Practice___Handling_Exceptions;

class Program
{
    static void Main(string[] args)
    {
        var calc = new Calculator();
        try
        {
            System.Console.WriteLine(calc.Add(14, 2));
        }
        catch (Exception ex) {
            System.Console.WriteLine(ex.Message);
            throw;
        }

    }
}
