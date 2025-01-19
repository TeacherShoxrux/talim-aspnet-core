namespace Talim.Data.Entity;
public class Subject
{
    public int SubjectId { get; set; }
    public string Name { get; set; }
    public int EducationTypeId { get; set; }
    public EducationType EducationType { get; set; }
    public ICollection<Theme> Themes { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
}
