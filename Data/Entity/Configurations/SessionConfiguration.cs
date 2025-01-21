namespace Talim.Data.Entity.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talim.Data.Entity;
public class SessionConfiguration : EntityBaseConfiguration<Session> { 
     public override void Configure(EntityTypeBuilder<Session> builder) {
        builder.Property(e => e.RefreshToken).IsRequired();
        builder.Property(e => e.AccessToken).IsRequired();
    }
}