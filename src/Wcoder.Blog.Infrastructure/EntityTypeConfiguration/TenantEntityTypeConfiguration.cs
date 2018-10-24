using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Wcoder.Blog.Protocol.Models;

namespace Wcoder.Blog.Infrastructure.EntityTypeConfiguration
{
    internal class TenantEntityTypeConfiguration
       : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            // builder.ToTable("Tenant");//需要引用sql

            //builder.HasKey(t => t.Id);
            //builder.Property(t => t.Id)
            //   .IsRequired();

            //builder.Property(t => t.Name)
            //    .IsRequired()
            //    .HasMaxLength(50);

            builder.HasIndex(b => b.Name)//索引  .HasIndex(b => new { b.Name, b.LogoUri }) //多列索引
              .IsUnique();//唯一索引
            builder.HasData(
                new Tenant
                {
                    Id = 1,
                    Name = "wcoder.com",
                    LogoId = "",
                    LogoUri = "",
                    Created = DateTime.UtcNow,
                    CreatedBy = 0,
                    Updated = DateTime.UtcNow
                }
           );
        }
    }
}