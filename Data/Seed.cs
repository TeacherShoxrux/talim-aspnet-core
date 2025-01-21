using Talim.Data.Entity;

namespace Talim.Data.Seed;

public static class Seed
{
    public static void SeedData(ApplicationDbContext context)
    {
        if (!context.Users.Any())
        {
            var users = new List<User>
            {
                new User { FirstName = "Admin",     LastName = "Admin", Password = new Password{PasswordHash = "123" ,Email="admin@admin.com"}, Role = EUserRole.Admin },
                new User { FirstName = "Moderator", LastName = "123",Password = new Password{PasswordHash = "123" ,Email="admin1@admin.com"}, Role = EUserRole.Moderator },
                new User { FirstName = "Teacher",   LastName = "123",Password = new Password{PasswordHash = "123" ,Email="admin2@admin.com"}, Role = EUserRole.Teacher },
                new User { FirstName = "Student",   LastName = "123",Password = new Password{PasswordHash = "123" ,Email="admin3@admin.com"}, Role = EUserRole.Student },
            };
            context.Users.AddRange(users);            
            context.SaveChanges();
        }}
    }
