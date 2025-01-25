using Microsoft.AspNetCore.Mvc;
using Talim.DTOs;
using Talim.Services;

namespace Talim.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EducationDirectionController : ControllerBase
{
    private readonly IEducationDirectionService _educationDirectionService;

    public EducationDirectionController(IEducationDirectionService educationDirectionService)
    {
        _educationDirectionService = educationDirectionService;
    }
     [HttpPost]
     public async Task<IActionResult> CreateEducationDirection(NewEducationDirection newEducationType)
    {
        int userId=1;
        var educationType = await _educationDirectionService.CreateEduDirection(userId,newEducationType);
        return Ok(educationType);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllEducationDirectionsByEduTypeId(int id)
    {
        var educationTypes = await _educationDirectionService.GetAllByEducationTypeId(id);
        return Ok(educationTypes);
    }

}