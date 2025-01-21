namespace Talim.Data.Entity.Configurations;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Talim.Data.Entity;        

    public class PasswordConfiguration : EntityBaseConfiguration<Password>
    {
        public override void Configure(EntityTypeBuilder<Password> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.PasswordHash).HasColumnType("char(64)").IsRequired();
            builder.Property(u => u.Email).HasColumnType("nvarchar(256)").IsRequired();

        }
    }