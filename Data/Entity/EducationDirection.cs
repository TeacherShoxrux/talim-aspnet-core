using System.ComponentModel.DataAnnotations;

namespace  Talim.Data.Entity;
public class EducationDirection : EntityBase 
{

    [Required]
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public int UserId { get; set; }
    public virtual User? User { get; set; }
    public int EducationTypeId { get; set; }
    public virtual EducationType? EducationType { get; set; }
    public virtual ICollection<Subject>? Subjects { get; set; }

    }