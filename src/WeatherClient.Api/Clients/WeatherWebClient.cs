using System.Net;
using Polly;
using Polly.Contrib.WaitAndRetry;

namespace WeatherClient.Api.Clients;

public class WeatherWebClient : IWeatherClient
{
    private const string ClientName = "weatherapi";
    private readonly IHttpClientFactory _httpClientFactory;
   
    public WeatherWebClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<IEnumerable<WeatherForecast>> GetWeather()
    {
        var cleint = _httpClientFactory.CreateClient(ClientName);
        var response = await cleint.GetAsync("WeatherForecast");
        return await response.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();
    }
}