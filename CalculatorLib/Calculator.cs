namespace CalculatorLib;

public class Calculator
{
    public double Add(double a, double b) {
        return a + b;
    }

    public void Gamma() {
        System.Console.WriteLine("It is Gamma()");

    }

    public void Delta() {
        System.Console.WriteLine("It is Delta()");
        File.OpenText("Bad file path");

    }
}
