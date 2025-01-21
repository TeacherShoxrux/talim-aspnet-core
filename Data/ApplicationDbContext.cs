using Microsoft.EntityFrameworkCore;
using Talim.Data.Entity;

namespace Talim.Data;
public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<EducationDirection> EducationDirections { get; set; }
    public DbSet<EducationType> EducationType { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Theme> Themes { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<ContentImage> ContentImages { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Password> Passwords { get; set; }
    

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }
    
}