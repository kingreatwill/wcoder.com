using System;
using System.Net.Http;
using System.Threading.Tasks;
using Wcoder.Blog.Protocol.Interfaces;
using Wcoder.Blog.Protocol.Models;

namespace Wcoder.Blog.AppClient
{
    public class WeatherForecastHttpClientService : IWeatherForecastService
    {
        private readonly HttpClient httpClient;
        private readonly string controllerName = "WeatherForecastService";
        private readonly string clientName = "WcoderBlog";

        public WeatherForecastHttpClientService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var url = $"/{controllerName}/{nameof(GetForecastAsync)}";
            var response = await httpClient.GetAsync(url);
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                return await ServiceStack.Text.JsonSerializer.DeserializeFromStreamAsync<WeatherForecast[]>(stream);
            }
        }
    }
}