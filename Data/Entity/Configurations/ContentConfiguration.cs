namespace Talim.Data.Entity.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talim.Data.Entity;
public class ContentConfiguration : IEntityTypeConfiguration<Content> {
    public void Configure(EntityTypeBuilder<Content> builder) {
        builder.Property(e => e.Name).HasColumnType("nvarchar(50)").IsRequired();
        builder.Property(e => e.ContentText).HasColumnType("nvarchar(max)").IsRequired();
    }
}