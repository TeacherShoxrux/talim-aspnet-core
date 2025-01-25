using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public partial class UserController : ControllerBase
{
     [HttpGet]
     public async Task<IActionResult> GetDataAdmin()
    {
        return Ok();
    }
}