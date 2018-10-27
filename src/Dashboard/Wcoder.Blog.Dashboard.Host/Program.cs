using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Wcoder.Blog.Dashboard.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration((hostingContext, config) =>
                 {
                     config.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                 })
                .UseUrls("http://localhost:5003")
                .UseStartup<Startup>()
                .Build();
    }
}