using Microsoft.AspNetCore.Mvc;
using WeatherClient.Api.Clients;

namespace WeatherClient.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherClient _weatherClient;

    public WeatherForecastController(IWeatherClient weatherClient, ILogger<WeatherForecastController> logger)
    {
        _weatherClient = weatherClient;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var response = await _weatherClient.GetWeather();
        return response;
    }
}