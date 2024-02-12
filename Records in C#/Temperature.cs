using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Records_in_C_;

public enum TemperatureScale {
    Celsius,
    Farenheit,
    Kelvin
}

public record Temperature (TemperatureScale Scale, decimal Value) : IEquatable<Temperature> {
    private static int precision = 5;

    // The lines below are intentionally commented. If you uncomment them, you should change the declaration signature of the record
    // Current declaration is prefered if you dont want to validate parameters before record instantiation.

    // IMPORTANT NOTE
    // You can declare properties as below and initialise them in a constructor. 
    // Parameters can be validated in the constructor.
    // If there is no need to validate the parameters, you can use the one-liner syntax as this record

    // public TemperatureScale Scale { get; init; }
    // public decimal Value { get; init; }

    // public Temperature(TemperatureScale scale, decimal value)
    // {
    //     VALIDATION can go here.
    //     Scale = scale;
    //     Value = value;
    // }
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
//        Trace.WriteLine("GetHashCode() fired!");

        return Scale switch {
            TemperatureScale.Kelvin => Math.Round(KelvinToCelsius(Value),precision).GetHashCode(),
            TemperatureScale.Farenheit => Math.Round(FarenheitToCelsius(Value), precision).GetHashCode(),
            TemperatureScale.Celsius => Math.Round(Value, precision).GetHashCode(),
            _ => 0
        };
    }
    public virtual bool Equals(Temperature? other) {
        if (other is not Temperature) return false; 
        return this.GetHashCode() == other.GetHashCode();
    }

}


