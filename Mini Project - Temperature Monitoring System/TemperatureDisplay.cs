
using System.Runtime.CompilerServices;

namespace Mini_Project___Temperature_Monitoring_System;

internal class TemperatureDisplay
{
    public TemperatureDisplay()
    {
    }

    public void RegisterSensor(TemperatureSensor sensor) {
        // sensor.TemperatureMeasured += OnTemperatureMeasured;
        sensor.TemperatureOverFifty += OnTemperatureOverFifty;
    }

    public void RegisterSensors(IEnumerable<TemperatureSensor> sensors) {
        foreach (var sensor in sensors)
        {
            sensor.TemperatureOverFifty += OnTemperatureOverFifty;
        }
    }
    private void OnTemperatureMeasured(object? sender, EventArgs args)
    {
        if (sender is null) return;
        TemperatureSensor? sensor = sender as TemperatureSensor;
        Console.WriteLine($"{sensor?.Name} : {sensor?.LastReading:N2}");
    }

    private void OnTemperatureOverFifty(object? sender, EventArgs args)
    {
        if (sender is null) return;
        TemperatureSensor? sensor = sender as TemperatureSensor;
        Console.WriteLine($"Warning, high temperatures - {sensor?.Name} : {sensor?.LastReading:N2}");
    }

}