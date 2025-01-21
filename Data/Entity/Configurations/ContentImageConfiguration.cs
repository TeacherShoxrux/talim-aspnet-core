namespace Talim.Data.Entity.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talim.Data.Entity;
public class ContentImageConfiguration : IEntityTypeConfiguration<ContentImage>
{
    public void Configure(EntityTypeBuilder<ContentImage> builder)
    {
        builder.Property(e => e.Title).HasColumnType("nvarchar(50)").IsRequired();
        builder.Property(e => e.Path).HasColumnType("nvarchar(512)").IsRequired();
    }
    }