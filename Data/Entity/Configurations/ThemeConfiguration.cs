namespace Talim.Data.Entity.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talim.Data.Entity;
public class ThemeConfiguration : EntityBaseConfiguration<Theme> { 
    public override void Configure(EntityTypeBuilder<Theme> builder) {
        base.Configure(builder);
        builder.Property(e => e.Name).HasColumnType("nvarchar(50)").IsRequired();
        builder.Property(e => e.Description).HasColumnType("nvarchar(256)").IsRequired();
        
    }
}