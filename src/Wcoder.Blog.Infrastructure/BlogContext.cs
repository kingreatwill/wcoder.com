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