using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Linq;
using System.Reflection;
using Wcoder.Blog.Application;
using Wcoder.Blog.Infrastructure;
using Wcoder.Blog.Protocol.Interfaces;
using Wcoder.Blog.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ManagedInjection
    {
        #region Services

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

            // services.AddHttpContextAccessor();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            // Services
            services.AddWcoderBlogServices();

            #region Session

            // Uncomment the following line to use the in-memory implementation of IDistributedCache
            services.AddDistributedMemoryCache();

            // Uncomment the following line to use the Microsoft SQL Server implementation of IDistributedCache.
            // Note that this would require setting up the session state database.
            //services.AddDistributedSqlServerCache(o =>
            //{
            //    o.ConnectionString = Configuration["AppSettings:ConnectionString"];
            //    o.SchemaName = "dbo";
            //    o.TableName = "Sessions";
            //});

            // Uncomment the following line to use the Redis implementation of IDistributedCache.
            // This will override any previously registered IDistributedCache service.
            //services.AddDistributedRedisCache(o =>
            //{
            //    o.Configuration = "localhost";
            //    o.InstanceName = "SampleInstance";
            //});

            services.AddSession(o =>
            {
                o.IdleTimeout = TimeSpan.FromSeconds(10);
            });

            #endregion Session
        }

        /// <summary>
        /// BlazorHostServer
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        public static void AddBlazorHostServerWcoderBlogServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddWcoderBlogServices(configuration);
            services.AddMvc().AddServicesMvc();
        }

        private static IMvcBuilder AddServicesMvc(this IMvcBuilder builder)
        {
            return builder.ConfigureApplicationPartManager(m => m.FeatureProviders.Add(new MvcFeatureProvider(builder.Services)));
        }

        #endregion Services

        #region App

        public static IApplicationBuilder UseWcoderBlogServices(this IApplicationBuilder app)
        {
            return app.UseSession();
        }

        #endregion App
    }
}