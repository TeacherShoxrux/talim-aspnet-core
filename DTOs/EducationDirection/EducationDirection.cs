namespace Talim.DTOs;

public class EducationDirection
{
    public int Id { get; set; }
    public string? Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Image { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

}