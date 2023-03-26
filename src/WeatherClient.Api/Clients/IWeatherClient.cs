namespace WeatherClient.Api.Clients;

public interface IWeatherClient
{
    Task<IEnumerable<WeatherForecast>> GetWeather();
}