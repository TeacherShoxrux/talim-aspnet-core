using System.ComponentModel.DataAnnotations;

namespace  Talim.Data.Entity;
public class Subject : EntityBase
{
    [Required]
    public string?  Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public int UserId { get; set; }
    public virtual User? User { get; set; }
    public int EducationDirectionId { get; set; }
    public virtual EducationDirection? EducationDirection { get; set; }
    public virtual ICollection<Theme>? Themes { get; set; }
    
}