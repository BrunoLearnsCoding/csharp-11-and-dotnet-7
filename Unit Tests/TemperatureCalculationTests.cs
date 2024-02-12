using Xunit;
using Records_in_C_;

namespace Unit_Tests;

public class TemperatureConversionTests
{
    [Fact]
    void Test_FarenheitToCelsius()
    {
        var tc = new Temperature(){ Scale = TemperatureScale.Celsius, Value = 0};
        var actual = tc.ToFarenheit();

        var expected = new Temperature() {Scale = TemperatureScale.Farenheit, Value = 32};

        Assert.Equal(expected,actual);
    }


}