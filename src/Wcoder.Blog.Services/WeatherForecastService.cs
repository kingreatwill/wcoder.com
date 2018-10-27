using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Wcoder.Blog.Infrastructure;
using Wcoder.Blog.Protocol.Interfaces;
using Wcoder.Blog.Protocol.Models;

namespace Wcoder.Blog.Services
{
    // [Microsoft.AspNetCore.Mvc.ControllerAttribute]
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly BlogContext blogContext;
        private readonly IRepository<Tenant> repository;
        private readonly IUnitOfWork unitOfWork;

        public WeatherForecastService(BlogContext blogContext, IRepository<Tenant> repository, IUnitOfWork unitOfWork)
        {
            this.blogContext = blogContext;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // [Microsoft.AspNetCore.Mvc.HttpGet()]
        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)] + " || " + repository.GetPagedList().Items.FirstOrDefault().Name
            }).ToArray());
        }
    }
}