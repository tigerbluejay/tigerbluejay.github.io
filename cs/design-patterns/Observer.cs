using System;
using System.Collections.Generic;

// Weather Station (Subject)
class WeatherStation
{
    private double temperature;
    private double humidity;
    private double pressure;
    private List<IDisplay> displays = new List<IDisplay>();

    public void AddDisplay(IDisplay display)
    {
        displays.Add(display);
    }

    public void RemoveDisplay(IDisplay display)
    {
        displays.Remove(display);
    }

    public void UpdateWeatherData(double temperature, double humidity, double pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        NotifyDisplays();
    }

    private void NotifyDisplays()
    {
        foreach (var display in displays)
        {
            display.Update(temperature, humidity, pressure);
        }
    }
}

// Display Interface (Observer)
interface IDisplay
{
    void Update(double temperature, double humidity, double pressure);
}

// Mobile App Display (Concrete Observer)
class MobileAppDisplay : IDisplay
{
    public void Update(double temperature, double humidity, double pressure)
    {
        Console.WriteLine("Mobile App Display:");
        Console.WriteLine($"Temperature: {temperature}°C");
        Console.WriteLine($"Humidity: {humidity}%");
        Console.WriteLine($"Pressure: {pressure} hPa");
        Console.WriteLine();
    }
}

// Website Display (Concrete Observer)
class WebsiteDisplay : IDisplay
{
    public void Update(double temperature, double humidity, double pressure)
    {
        Console.WriteLine("Website Display:");
        Console.WriteLine($"Temperature: {temperature}°C");
        Console.WriteLine($"Humidity: {humidity}%");
        Console.WriteLine($"Pressure: {pressure} hPa");
        Console.WriteLine();
    }
}

// Program (Client)
class Program
{
    static void Main(string[] args)
    {
        // Create a weather station
        var weatherStation = new WeatherStation();

        // Create displays (observers)
        var mobileAppDisplay = new MobileAppDisplay();
        var websiteDisplay = new WebsiteDisplay();

        // Register displays with the weather station
        weatherStation.AddDisplay(mobileAppDisplay);
        weatherStation.AddDisplay(websiteDisplay);

        // Simulate weather updates
        weatherStation.UpdateWeatherData(25.5, 70.2, 1013.2);
        weatherStation.UpdateWeatherData(27.8, 65.9, 1012.8);

        // Unregister the mobile app display
        weatherStation.RemoveDisplay(mobileAppDisplay);

        // Simulate another weather update
        weatherStation.UpdateWeatherData(29.1, 72.6, 1014.5);

        Console.ReadLine();
    }
}