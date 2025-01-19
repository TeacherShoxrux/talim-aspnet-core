namespace Talim.Data.Entity;
public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

public enum UserRole
{
    Student,
    Teacher,
    Admin
}
