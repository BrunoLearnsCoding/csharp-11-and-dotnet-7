/// To practice delegates and events I wrote this project


using System.Globalization;

namespace Mini_Project___Temperature_Monitoring_System;

class Program
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");
        var sensors = new List<TemperatureSensor>();
        sensors.Add(new TemperatureSensor("Sensor A"));
        sensors.Add(new TemperatureSensor("Sensor B"));
        TemperatureDisplay display = new TemperatureDisplay();
        display.RegisterSensors(sensors);


        SimulateRandomMeasurement(sensors);
    }

    public static void SimulateRandomMeasurement(IEnumerable<TemperatureSensor> sensors)
    {
        do
        {
            var randomTimeInMiliseconds = Random.Shared.Next(1000, 4000);
            Thread.Sleep(randomTimeInMiliseconds);
            foreach (var sensor in sensors)
            {
                sensor.Measure();
            }
        } while (true);
    }


}
