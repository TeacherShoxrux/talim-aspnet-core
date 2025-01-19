using Microsoft.EntityFrameworkCore;
using Talim.Data.Entity;

namespace Talim.Data;
public class ApplicationDbContext : DbContext
{
public DbSet<User> Users { get; set; }
    public DbSet<EducationType> EducationTypes { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Theme> Themes { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define relationships
        modelBuilder.Entity<Subject>()
            .HasOne(s => s.EducationType)
            .WithMany(e => e.Subjects)
            .HasForeignKey(s => s.EducationTypeId);

        modelBuilder.Entity<Theme>()
            .HasOne(t => t.Subject)
            .WithMany(s => s.Themes)
            .HasForeignKey(t => t.SubjectId);

        modelBuilder.Entity<Content>()
            .HasOne(c => c.Theme)
            .WithMany(t => t.Contents)
            .HasForeignKey(c => c.ThemeId);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.User)
            .WithMany(u => u.Enrollments)
            .HasForeignKey(e => e.UserId);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Subject)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.SubjectId);
    }
    
}