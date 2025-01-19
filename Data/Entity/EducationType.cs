namespace Talim.Data.Entity;
public class EducationType
{
    public int EducationTypeId { get; set; }
    public string Name { get; set; }
    public ICollection<Subject> Subjects { get; set; }
}
