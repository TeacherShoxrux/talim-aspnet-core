namespace Talim.Data.Entity;
public class User : EntityBase
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Image { get; set; }
    public EUserRole Role { get; set; }=EUserRole.Student;
    public virtual Session? Session { get; set; }
    public virtual Password? Password { get; set; }
    public virtual ICollection<EducationType>? EducationTypes { get; set; }
    public virtual ICollection<EducationDirection>? EducationDirections { get; set; }
    public virtual ICollection<Subject>? Subjects { get; set; }
    public virtual ICollection<Theme>? Themes { get; set; }
    public virtual ICollection<ContentImage>? ContentImages { get; set; }
    public virtual ICollection<Content>? Contents { get; set; }
}

