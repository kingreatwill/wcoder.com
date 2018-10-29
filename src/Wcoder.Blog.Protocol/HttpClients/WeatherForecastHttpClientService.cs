using System;
using System.Net.Http;
using System.Threading.Tasks;
using Wcoder.Blog.Protocol.Interfaces;
using Wcoder.Blog.Protocol.Models;

namespace Wcoder.Blog.Protocol.HttpClients
{
    public class WeatherForecastHttpClientService : IWeatherForecastService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly HttpClient httpClient;
        private readonly string controllerName = "WeatherForecastService";
        private readonly string clientName = "WcoderBlog";

        public WeatherForecastHttpClientService(IHttpClientFactory httpClientFactory, HttpClient httpClient)
        {
            this.httpClientFactory = httpClientFactory;
            this.httpClient = httpClient;
        }

        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var url = $"/{controllerName}/{nameof(GetForecastAsync)}";
            var client = httpClientFactory.CreateClient(clientName);
            var r = await client.GetAsync(url);

            using (var stream = await r.Content.ReadAsStreamAsync())
            {
                return await ServiceStack.Text.JsonSerializer.DeserializeFromStreamAsync<WeatherForecast[]>(stream);
            }
        }
    }
}