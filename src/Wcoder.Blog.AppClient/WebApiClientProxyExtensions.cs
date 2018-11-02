
using System;
using Wcoder.Blog.AppClient;
using Wcoder.Blog.Protocol.Interfaces;
namespace Microsoft.Extensions.DependencyInjection
{
    public static class WebApiClientProxyExtensions
    {
        public static void AddBlazorHostClientWcoderBlogServices(this IServiceCollection services)
        {
            // Services			
			services.AddScoped<IWcoderBlogService, HttpClientWcoderBlogService>();
			services.AddScoped<IWcoderCollectService, HttpClientWcoderCollectService>();
			services.AddScoped<IWeatherForecastService, HttpClientWeatherForecastService>();
        }
    }
}


