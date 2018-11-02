using System;
using Wcoder.Blog.Services;
using Wcoder.Blog.Protocol.Interfaces;
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWcoderBlogServices(this IServiceCollection services)
        {
            // Services			
			services.AddScoped<IWcoderBlogService, WcoderBlogService>();
			services.AddScoped<IWcoderCollectService, WcoderCollectService>();
			services.AddScoped<IWeatherForecastService, WeatherForecastService>();
        }
    }
}
