using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wcoder.Blog.Protocol.Models;

namespace Wcoder.Blog.Infrastructure.EntityTypeConfiguration
{
    internal class CatalogEntityTypeConfiguration
       : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            //builder.ToTable("Catalog");//需要引用sql

            //builder.HasKey(t => t.Id);
            //builder.Property(t => t.Id)
            //   .IsRequired();

            //builder.Property(t => t.Name)
            //    .IsRequired()
            //    .HasMaxLength(50);
        }
    }
}