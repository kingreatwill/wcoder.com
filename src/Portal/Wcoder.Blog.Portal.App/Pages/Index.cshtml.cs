using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wcoder.Blog.Protocol.Interfaces;
using Wcoder.Blog.Protocol.Models;

namespace Wcode.Blog.Portal.App.Pages
{
    public class IndexModel : PageModel
    {
        private IWeatherForecastService weatherForecastService;

        public IndexModel(IWeatherForecastService weatherForecastService, IWcoderBlogService sd)
        {
            this.weatherForecastService = weatherForecastService;
        }

        public WeatherForecast[] Message { get; set; }

        public async Task OnGetAsync()
        {
            Message = await weatherForecastService.GetForecastAsync(DateTime.Now);
        }
    }
}