using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Talim.Services;
public class UserRegister
{
     [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    [MinLength(4)]
    public required string Password { get; set; }
}