using System;

namespace Wcoder.Blog.Application
{
    public static class ManagedInjection
    {
        public static void AddWcoderBlogServices(this IServiceCollection services)
        {
            var sqlConnectionString = Configuration.GetConnectionString("DataAccessMsSqlServerProvider");

            services.AddDbContext<DomainModelMsSqlServerContext>(options =>
                options.UseSqlServer(
                    sqlConnectionString,
                    b => b.MigrationsAssembly("AspNetCoreMultipleProject")
                )
            );
        }
    }
}