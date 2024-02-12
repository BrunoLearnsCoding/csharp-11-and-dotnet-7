namespace Mini_Project___Temperature_Monitoring_System;


public class TemperatureSensor {
    public EventHandler? TemperatureMeasured;       // It seems, there is no difference with the line below
    public event EventHandler? TemperatureOverFifty;

    public decimal LastReading {get; private set;}
    public string Name { get; init; }
    public TemperatureSensor(string Name)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(Name);
        this.Name = Name;
    }
    public void Measure() {
        var randomTemperature = Random.Shared.NextDouble() * 100;
        LastReading = (decimal) randomTemperature;
        if (TemperatureMeasured is not null) {
            TemperatureMeasured(this, new EventArgs());
        }
        if (TemperatureOverFifty is not null) {
            if (LastReading > 50) TemperatureOverFifty(this, new EventArgs());
        }
    }

}