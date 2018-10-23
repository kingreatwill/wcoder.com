using System;
using System.Linq;
using System.Threading.Tasks;
using Wcoder.Blog.Protocol.Models;

namespace Wcoder.Blog.Protocol.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
    }
}