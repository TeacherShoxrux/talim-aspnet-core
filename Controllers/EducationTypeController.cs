using Microsoft.AspNetCore.Mvc;
using Talim.DTOs;

namespace Talim.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EducationTypeController : ControllerBase
{
    private readonly IEducationTypeService _educationTypeService;

    public EducationTypeController(IEducationTypeService educationTypeService)
    {
        _educationTypeService = educationTypeService;
    }
    [HttpPost]
     public async Task<IActionResult> AddEducationType(NewEducationType newEducationType)
    {
        var educationType = await _educationTypeService.Add(1,newEducationType);
        return Ok(educationType);
    }
    [HttpGet]
     public async Task<IActionResult> GetAll()
    {
        var educationTypes = await _educationTypeService.GetAll();
        return Ok(educationTypes);
    }
     
     [HttpDelete("{id}")]
     public async Task<IActionResult> DeleteById(int id){
        int userId=1;
        var educationDirection = await _educationTypeService.Delete(userId,id);
        return Ok(educationDirection);
     }
}