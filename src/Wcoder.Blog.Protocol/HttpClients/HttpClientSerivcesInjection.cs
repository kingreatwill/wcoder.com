using Polly;
using System;
using Wcoder.Blog.Protocol.HttpClients;
using Wcoder.Blog.Protocol.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class HttpClientSerivcesInjection
    {
        /// <summary>
        /// WcoderBlog
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        public static void AddBlazorHostClientWcoderBlogServices(this IServiceCollection services)
        {
            services.AddHttpClient("GitHub", client =>
            {
                client.BaseAddress = new Uri("https://api.github.com/");
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            }).AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
            {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(3)
            }));

            // Services
            services.AddScoped<IWeatherForecastService, WeatherForecastHttpClientService>();
            services.AddScoped<IWcoderBlogService, WcoderBlogHttpClientService>();
        }
    }
}