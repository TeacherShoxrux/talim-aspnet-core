using System.ComponentModel.DataAnnotations;

namespace  Talim.Data.Entity;
public class EducationDirection : EntityBase 
{

    [Required]
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public int TypeId { get; set; }
    public Type? Type { get; set; }
    public ICollection<Subject>? Subjects { get; set; }

    }