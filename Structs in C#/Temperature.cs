// Temperature struct

using System.Diagnostics;

public enum TemperatureScale {
    Celsius,
    Farenheit,
    Kelvin
}

public struct Temperature {
    private static int precision = 5;
    public TemperatureScale Scale { get; init; }
    public decimal Value { get; init; }
    public Temperature(TemperatureScale scale, decimal value)
    {
        Scale = scale;
        Value = value;
    }
    public Temperature ToCelsius() {
        return Scale switch {
            TemperatureScale.Kelvin => new Temperature(TemperatureScale.Celsius, KelvinToCelsius(Value)),
            TemperatureScale.Farenheit => new Temperature(TemperatureScale.Celsius, FarenheitToCelsius(Value)),
            _ => this
        };
    }

    public Temperature ToFarenheit() {
        return Scale switch {
            TemperatureScale.Celsius => new Temperature(TemperatureScale.Farenheit, CelsiusToFarenheit(Value)),
            TemperatureScale.Kelvin => new Temperature(TemperatureScale.Farenheit, KelvinToFarenheit(Value)),
            _ => this
        };
    }
    public Temperature ToKelvin() {
        return Scale switch {
            TemperatureScale.Celsius => new Temperature(TemperatureScale.Kelvin, CelsiusToKelvin(Value)),
            TemperatureScale.Farenheit => new Temperature(TemperatureScale.Kelvin, FarenheitToKelvin(Value)),
            _ => this
        };
    }


    private static decimal CelsiusToFarenheit(decimal valueInCelsius) {

        return (valueInCelsius * 1.8M) + 32;
    }

    private static decimal FarenheitToCelsius(decimal valueInFarenheit) {
        return (valueInFarenheit - 32) / 1.8M;
    }

    private static decimal KelvinToFarenheit(decimal valueInKelvin) {
        return 1.8M * (valueInKelvin-273.15M) + 32;
    }

    private static decimal FarenheitToKelvin(decimal valueInFarenheit) {
        return ((valueInFarenheit-32) * 5 / 9) + 273.15M;
    }

    private static decimal CelsiusToKelvin(decimal valueInCelsius) {
        return valueInCelsius + 273.15M;
    }

    private static decimal KelvinToCelsius(decimal valueInKelvin) {
        return valueInKelvin - 273.15M;
    }
    public override int GetHashCode()
    {
        Trace.WriteLine("GetHashCode() fired!");

        return Scale switch {
            TemperatureScale.Kelvin => Math.Round(KelvinToCelsius(Value),precision).GetHashCode(),
            TemperatureScale.Farenheit => Math.Round(FarenheitToCelsius(Value), precision).GetHashCode(),
            TemperatureScale.Celsius => Math.Round(Value, precision).GetHashCode(),
            _ => 0
        };
    }
    public override bool Equals(object? obj) {
        return obj is Temperature other && this.Equals(other);
    }

    public static bool operator ==(Temperature temp1, Temperature temp2) => temp1.Equals(temp2); 
    public static bool operator !=(Temperature temp1, Temperature temp2) => !(temp1 == temp2); 
}