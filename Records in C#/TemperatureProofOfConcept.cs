using System.Diagnostics;
using System.Globalization;

namespace Records_in_C_;

public class TemperatureProofOfConcept {
    public TemperatureProofOfConcept()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
    }

    public void ProofCelsiusToFarenheitConversion(decimal[] temps) {
        var temperaturesInCelsius = new List<Temperature>();
        var convertedFarenheit = new List<Temperature>();
        var convertedToCelcius = new List<Temperature>();

        foreach (decimal temp in temps) {
            temperaturesInCelsius.Add(new Temperature(TemperatureScale.Celsius, temp));
        }

        foreach (Temperature temp in temperaturesInCelsius) {
            var converted = temp.ToFarenheit();
            convertedFarenheit.Add(converted);
            convertedToCelcius.Add(converted.ToCelsius()!);
        }
        for (int i = 0; i < temps.Length; i++) 
        {
            System.Console.WriteLine($"{temperaturesInCelsius[i].Value:N10} {convertedFarenheit[i].Value:N10} {convertedToCelcius[i].Value:N10} {temperaturesInCelsius[i] == convertedToCelcius[i]}");
            if (temperaturesInCelsius[i] != convertedToCelcius[i]) {
                throw new Exception();
            }
        }

    }
    public void ProofFarenheitToCelsiusConversion(decimal[] temps) {

        var temperaturesInFarenheit = new List<Temperature>();
        var convertedToCelsius = new List<Temperature>();
        var convertedToFarenheit = new List<Temperature>();

        foreach (decimal temp in temps) {
            temperaturesInFarenheit.Add(new Temperature(TemperatureScale.Farenheit, temp));
        }

        foreach (Temperature temp in temperaturesInFarenheit) {
            var converted = temp.ToCelsius();
            convertedToCelsius.Add(converted);
            convertedToFarenheit.Add(converted.ToFarenheit()!);
        }
        for (int i = 0; i < temps.Length; i++) 
        {
            System.Console.WriteLine($"{temperaturesInFarenheit[i].Value:N10} {convertedToCelsius[i].Value:N10} {convertedToFarenheit[i].Value:N10} {temperaturesInFarenheit[i] == convertedToFarenheit[i]}");
            if (temperaturesInFarenheit[i] != convertedToFarenheit[i]) {
                System.Console.WriteLine("Exception occured!");
                System.Console.WriteLine($"{temperaturesInFarenheit[i]} {convertedToFarenheit[i]}");
                System.Console.WriteLine($"{temperaturesInFarenheit[i].GetHashCode():N20} {convertedToFarenheit[i].GetHashCode():N20}");
                System.Console.WriteLine($"Equals : {temperaturesInFarenheit[i].Equals(convertedToFarenheit[i])}");
                throw new Exception();
            }
            if (temperaturesInFarenheit[i].Value != convertedToFarenheit[i].Value) {
                Trace.WriteLine($"{temperaturesInFarenheit[i].Value} {convertedToFarenheit[i].Value}");
            }
        }
    }
    public static decimal[] GetAnArrayWithIncrement(decimal start, int count, decimal increment) {
        var output = new decimal[count];
        output[0] = start;
        for (int i = 1; i < count; i++) {
            output[i] = output[i-1] + increment;  
        }
        return output;

    }
}