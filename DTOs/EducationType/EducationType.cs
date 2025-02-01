namespace Talim.DTOs;
public class EducationType{
    public int Id { get; set; }=0;
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}