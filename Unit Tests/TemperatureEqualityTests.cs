using Records_in_C_;
using Xunit;
namespace Unit_Tests;

public class TemperatureEqualityTests {

    [Theory]
    [InlineData(32, 0)]
    [InlineData(212.5, 100.28)]
    [InlineData(100.28, 212.5)]

    void Test_TemperaturesInDifferentScalesAreEqual(decimal valueInFarenheit, decimal valueInCelsius) {
        var tc = new Temperature() {Scale = TemperatureScale.Celsius, Value = valueInCelsius};
        var tf = new Temperature() {Scale = TemperatureScale.Farenheit, Value = valueInFarenheit};

        Assert.True(tc == tf);


    }

}