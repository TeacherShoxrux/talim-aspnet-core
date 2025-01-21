namespace Talim.Data.Entity.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talim.Data.Entity;

public class UserEntityConfiguration : EntityBaseConfiguration<User>{
    public override void Configure(EntityTypeBuilder<User> builder){
        base.Configure(builder);
        builder.Property(u => u.FirstName).HasColumnType("nvarchar(50)");
        builder.Property(u => u.LastName).HasColumnType("nvarchar(50)");
        builder.Property(u => u.Image).HasColumnType("nvarchar(256)");
        builder.Property(u => u.PhoneNumber).HasColumnType("nvarchar(20)");
        builder.Property(u => u.Email).HasColumnType("nvarchar(256)").IsRequired();
        builder.Property(u => u.Role).IsRequired();
    }
}