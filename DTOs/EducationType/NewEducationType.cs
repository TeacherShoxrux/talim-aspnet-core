using System.ComponentModel.DataAnnotations;

namespace Talim.DTOs;
public class NewEducationType
{
    [Required]
    public string? Name { get; set; }
    public string? Description { get; set; }
}