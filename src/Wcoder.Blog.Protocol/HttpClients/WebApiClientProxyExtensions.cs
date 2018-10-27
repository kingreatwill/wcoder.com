using Polly;
using System;
using Wcoder.Blog.Protocol.HttpClients;
using Wcoder.Blog.Protocol.Interfaces;
namespace Microsoft.Extensions.DependencyInjection
{
    public static class WebApiClientProxyExtensions
    {
        public static void AddBlazorHostClientWcoderBlogServices(this IServiceCollection services)
        {
            services.AddHttpClient("WcoderBlog", client =>
            {
                client.BaseAddress = new Uri("http://localhost:5003");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            }).AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
            {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(3)
            }));

            // Services
			services.AddScoped<IWcoderBlogService, WcoderBlogHttpClientService>();
			services.AddScoped<IWeatherForecastService, WeatherForecastHttpClientService>();
        }
    }
}


