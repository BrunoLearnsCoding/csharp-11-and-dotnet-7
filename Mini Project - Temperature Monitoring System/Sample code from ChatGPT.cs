// TemperatureSensor class with delegate
public class TemperatureSensor
{
    public delegate void TemperatureChangedEventHandler(double temperature);
    public event TemperatureChangedEventHandler? TemperatureChanged;

    private readonly Random random = new Random();

    public void SimulateTemperatureChange()
    {
        double newTemperature = random.Next(0, 100);
        Console.WriteLine($"New Temperature Reading: {newTemperature}Â°C");
        OnTemperatureChanged(newTemperature);
    }

    protected virtual void OnTemperatureChanged(double temperature)
    {
        TemperatureChanged?.Invoke(temperature);
    }
}

// TemperatureDisplay class subscribing to TemperatureSensor events
public class TemperatureDisplay
{
    public void OnTemperatureChanged(double temperature)
    {
        Console.WriteLine($"Temperature Display Updated: {temperature}°C");
    }
}

// Main program
class Program
{
    static void _Main()
    {
        TemperatureSensor sensor = new TemperatureSensor();
        TemperatureDisplay display = new TemperatureDisplay();

        // Subscribe display to sensor events
        sensor.TemperatureChanged += display.OnTemperatureChanged;

        // Simulate temperature changes
        for (int i = 0; i < 5; i++)
        {
            sensor.SimulateTemperatureChange();
        }
    }
}
