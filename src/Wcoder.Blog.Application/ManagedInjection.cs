using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Wcoder.Blog.Infrastructure;
using Wcoder.Blog.Protocol.Interfaces;
using Wcoder.Blog.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ManagedInjection
    {
        /// <summary>
        /// WcoderBlog
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        public static void AddWcoderBlogServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DB
            var sqlConnectionString = configuration.GetConnectionString("BlogConnection");

            services.AddDbContext<BlogContext>(options =>
                options.UseSqlServer(sqlConnectionString, b => b.MigrationsAssembly("Wcoder.Blog.Portal.Server"))
            ).AddUnitOfWork<BlogContext>();//.AddCustomRepository<Blog, CustomBlogRepository>()
                                           //https://github.com/Arch/UnitOfWork
            services.AddScoped(typeof(DbContext), typeof(BlogContext));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            // Services
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            services.AddScoped<IWcoderBlogService, WcoderBlogService>();
        }
    }
}