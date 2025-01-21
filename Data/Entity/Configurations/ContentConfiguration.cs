namespace Talim.Data.Entity.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talim.Data.Entity;
public class ContentConfiguration : EntityBaseConfiguration<Content> {
    public override void Configure(EntityTypeBuilder<Content> builder) {
        base.Configure(builder);
        builder.Property(e => e.Name).HasColumnType("nvarchar(50)").IsRequired();
        builder.Property(e => e.ContentText).IsRequired();
    }
}