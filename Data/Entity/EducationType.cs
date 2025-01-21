namespace  Talim.Data.Entity;
public class EducationType : EntityBase{
    
    public string? Name { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
    public int UserId { get; set; }
    public virtual User? User { get; set; }
    public virtual ICollection<EducationDirection>? EducationDirections { get; set; }
}