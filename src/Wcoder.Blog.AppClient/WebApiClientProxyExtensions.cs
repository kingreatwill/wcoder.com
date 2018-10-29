﻿using System;
using Wcoder.Blog.AppClient;
using Wcoder.Blog.Protocol.Interfaces;
namespace Microsoft.Extensions.DependencyInjection
{
    public static class WebApiClientProxyExtensions
    {
        public static void AddBlazorHostClientWcoderBlogServices(this IServiceCollection services)
        {
            // Services
			services.AddScoped<IWeatherForecastService, WeatherForecastHttpClientService>();
			services.AddScoped<IWcoderBlogService, WcoderBlogHttpClientService>();
        }
    }
}

