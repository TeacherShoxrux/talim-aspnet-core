namespace Talim.Data.Entity;
public class User : EntityBase
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public  Password? password { get; set; }
    public ICollection<Session?>? Session { get; set; }
    public ICollection<EducationType?>? EducationType { get; set; }
    public EducationDirection? EducationDirection { get; set; }
    public ICollection<Subject?>? Subjects { get; set; }
    public ICollection<Theme?>? Themes { get; set; }
    public ICollection<ContentImage?>? ContentImage { get; set; }
    public UserRole Role { get; set; }=UserRole.Student;
}

