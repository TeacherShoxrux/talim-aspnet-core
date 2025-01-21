using Talim.Data.Entity;
using Talim.Utils;

namespace Talim.Data.Seed;

public static class Seed
{
    public static void SeedData(ApplicationDbContext context)
    {
        if (!context.Users.Any())
        {
            var users = new List<User>
            {
                new User { FirstName = "Admin",     LastName = "Admin", Password = new Password{PasswordHash = "123".Sha256() ,Email="admin@admin.com"}, Role = EUserRole.Admin },
                new User { FirstName = "Moderator", LastName = "Admin",Password = new Password{PasswordHash = "123".Sha256() ,Email="admin1@admin.com"}, Role = EUserRole.Moderator },
                new User { FirstName = "Teacher",   LastName = "Admin",Password = new Password{PasswordHash = "123".Sha256() ,Email="admin2@admin.com"}, Role = EUserRole.Teacher },
                new User { FirstName = "Student",   LastName = "Admin",Password = new Password{PasswordHash = "123".Sha256() ,Email="admin3@admin.com"}, Role = EUserRole.Student },
            };
            context.Users.AddRange(users);            
            context.SaveChanges();
        }}
    }
