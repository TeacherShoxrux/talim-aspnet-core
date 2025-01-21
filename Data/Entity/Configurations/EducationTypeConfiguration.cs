using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Talim.Data.Entity.Configurations;

    public class EducationTypeConfiguration : EntityBaseConfiguration<EducationType>
    {
        public override void Configure(EntityTypeBuilder<EducationType> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Name).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(e => e.Description).HasColumnType("nvarchar(256)");
            builder.Property(u => u.Image).HasColumnType("nvarchar(256)");
            
        }
    }
