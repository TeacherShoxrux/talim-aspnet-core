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
        //content image foreign key
       modelBuilder.Entity<ContentImage>()
            .HasOne(s => s.Content)
            .WithMany(e => e.ContentImages)
            .HasForeignKey(s => s.ContentId);
         modelBuilder.Entity<ContentImage>()
            .HasOne(s => s.User)
            .WithMany(e => e.ContentImages)
            .HasForeignKey(s => s.UserId);

        // content foreign key
        modelBuilder.Entity<Content>()
            .HasOne(s => s.Theme)
            .WithMany(e => e.Contents)
            .HasForeignKey(s => s.ThemeId);
        modelBuilder.Entity<Content>()
            .HasOne(s => s.User)
            .WithMany(e => e.Contents)
            .HasForeignKey(s => s.UserId);

        //theme foreign key
        modelBuilder.Entity<Theme>()
            .HasOne(s => s.Subject)
            .WithMany(e => e.Themes)
            .HasForeignKey(s => s.SubjectId);

        modelBuilder.Entity<Theme>()
            .HasOne(s => s.User)
            .WithMany(e => e.Themes)
            .HasForeignKey(s => s.UserId);

        //subject foreign key
        modelBuilder.Entity<Subject>()
            .HasOne(s => s.EducationDirection)
            .WithMany(e => e.Subjects)
            .HasForeignKey(s => s.EducationDirectionId);
        modelBuilder.Entity<Subject>()
            .HasOne(s => s.User)
            .WithMany(e => e.Subjects)
            .HasForeignKey(s => s.UserId);

        //education direction foreign key
        modelBuilder.Entity<EducationDirection>()
            .HasOne(s => s.EducationType)
            .WithMany(e => e.EducationDirections)
            .HasForeignKey(s => s.EducationTypeId);
        
        modelBuilder.Entity<EducationDirection>()
            .HasOne(s => s.User)
            .WithMany(e => e.EducationDirections)
            .HasForeignKey(s => s.UserId);

        //education type foreign key
        modelBuilder.Entity<EducationType>()
            .HasOne(s => s.User)
            .WithMany(e => e.EducationTypes)
            .HasForeignKey(s => s.UserId);
    
        //user foreign key
        modelBuilder.Entity<User>()
            .HasOne(s => s.Password)
            .WithOne(e => e.User)
            .HasForeignKey<Password>(s => s.UserId);
        
        modelBuilder.Entity<User>()
            .HasOne(s => s.Session)
            .WithOne(e => e.User)
            .HasForeignKey<Session>(s => s.UserId);

        //session foreign key
        modelBuilder.Entity<Session>()
            .HasOne(s => s.User)
            .WithOne(e => e.Session)
            .HasForeignKey<Session>(s => s.UserId);

    }
    
}