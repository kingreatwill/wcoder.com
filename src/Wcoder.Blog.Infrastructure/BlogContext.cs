using Microsoft.EntityFrameworkCore;
using System;
using Wcoder.Blog.Infrastructure.EntityTypeConfiguration;
using Wcoder.Blog.Protocol.Models;

namespace Wcoder.Blog.Infrastructure
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<Catalog> Catalogs { get; set; }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TenantEntityTypeConfiguration());
        }
    }
}

/*

MS SQL Server
dotnet restore

dotnet ef migrations add mssqlMigration --context DomainModelMsSqlServerContext

dotnet ef database update --context DomainModelMsSqlServerContext

SQLite
dotnet restore

dotnet ef migrations add sqliteMigration --context DomainModelSqliteContext

dotnet ef database update --context DomainModelSqliteContext

PostGreSQL
dotnet restore

dotnet ef migrations add postgresqlMigration --context DomainModelPostgreSqlContext

dotnet ef database update --context DomainModelPostgreSqlContext

MySQL
dotnet restore

dotnet ef migrations add mySqlMigration --context DomainModelMySqlContext

dotnet ef database update --context DomainModelMySqlContext

*/