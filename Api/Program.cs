using System.Diagnostics;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/version",
    () =>
    {
        var entryAssembly = Assembly.GetEntryAssembly()!;
        var informationalVersion = FileVersionInfo.GetVersionInfo(entryAssembly.Location).ProductVersion;

        return new
        {
            info = informationalVersion,
        };
    });

var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

app.MapGet(
    "/weatherforecast",
    () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast(DateOnly.FromDateTime(DateTime.Now.AddDays(index)), Random.Shared.Next(-20, 55), summaries[Random.Shared.Next(summaries.Length)])).ToArray();
        return forecast;
    });

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}