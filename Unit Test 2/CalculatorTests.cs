using System.Diagnostics;

namespace Unit_Test;

public class CalculatorTests
{
    [Fact]
    public void TestAdding2and2()
    {
        double a = 2;
        double b = 2;
        double expected = 4;
        var calculator = new CalculatorLib.Calculator();
        var actual = calculator.Add(a,b);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestAdding2and3() {
        double a = 2;
        double b = 3;
        double expected = 5;
        var calculator = new CalculatorLib.Calculator();
        var actual = calculator.Add(a,b);
        Assert.Equal(expected, actual);


    }
}