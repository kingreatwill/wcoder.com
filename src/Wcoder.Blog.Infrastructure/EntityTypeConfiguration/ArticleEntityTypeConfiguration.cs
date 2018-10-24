using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wcoder.Blog.Protocol.Models;

namespace Wcoder.Blog.Infrastructure.EntityTypeConfiguration
{
    internal class ArticleEntityTypeConfiguration
       : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //builder.ToTable("Article");//需要引用sql

            //builder.HasKey(t => t.Id);
            //builder.Property(t => t.Id)
            //   .IsRequired();

            //builder.Property(t => t.Title)
            //    .IsRequired()
            //    .HasMaxLength(50);
        }
    }
}