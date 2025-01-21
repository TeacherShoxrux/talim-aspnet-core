namespace Talim.Data.Entity.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talim.Data.Entity;

public class SubjectConfiguration : EntityBaseConfiguration<Subject>
{
    public override void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.Property(e => e.Name).HasColumnType("nvarchar(50)").IsRequired();
        builder.Property(e => e.Description).HasColumnType("nvarchar(256)");
        builder.Property(u => u.Image).HasColumnType("nvarchar(256)");
        base.Configure(builder);
    }
}