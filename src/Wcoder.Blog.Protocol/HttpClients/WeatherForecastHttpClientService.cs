using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Wcoder.Blog.Protocol.Interfaces;
using Wcoder.Blog.Protocol.Models;

namespace Wcoder.Blog.Protocol.HttpClients
{
    public class WeatherForecastHttpClientService : IWeatherForecastService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public WeatherForecastHttpClientService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            string[] Summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
            //var client = _httpClientFactory.CreateClient("GitHub");
            // return Ok(await client.GetStringAsync("/someapi"));
            return null;
        }
    }
}