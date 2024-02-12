using MathClassLib;
namespace Unit_Tests;

public class PrimeHelperTests
{

    [Fact]
    public void TestGetPrimeNumbersLessThan10()
    {
        var n = 10;
        var expected = new List<int>() {2,3,5,7};
        var actual = PrimeHelper.GetPrimeNumbersLessThanOrEqual(n);
        Assert.Equal(expected, actual);

    }

    [Fact]
    public void TestGetPrimeFactorsOf10InText() {
        var n = 10;
        var expected = "2 x 5";
        var actual = PrimeHelper.GetPrimeFactorsInText(n);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestGetPrimeFactorsOf51InText() {
        var n = 51;
        var expected = "3 x 17";
        var actual = PrimeHelper.GetPrimeFactorsInText(n);
        Assert.Equal(expected, actual);
    }    

    [Fact]
    public void TestGetPrimeFactorsOf17InText() {
        var n = 17;
        var expected = "17";
        var actual = PrimeHelper.GetPrimeFactorsInText(n);
        Assert.Equal(expected, actual);
    }    

    [Fact]
    public void TestGetPrimeFactorsOf178InText() {
        var n = 178;
        var expected = "2 x 89";
        var actual = PrimeHelper.GetPrimeFactorsInText(n);
        Assert.Equal(expected, actual);
    }    

}
