namespace  Talim.Data.Entity;
public class Type{
    
    public string? Name { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
    public int? UserId { get; set; }
    public virtual User? User { get; set; }
    public ICollection<EducationDirection>? EducationDirections { get; set; }
}