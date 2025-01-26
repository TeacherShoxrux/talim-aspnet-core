using Microsoft.AspNetCore.Mvc;
using Talim.DTOs;
using Talim.Repositories;
using Talim.Services;

namespace Talim.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ThemeController : ControllerBase
{
    private readonly IThemeService _themeService;

    public ThemeController(IThemeService themeService)
    {
        _themeService = themeService;
    }

    [HttpGet("Create/{subjectId}")]
     public async Task<IActionResult> AddTheme(int subjectId)
    {
        var userId=1;
        var theme = await _themeService.CreateTheme(userId,subjectId);
       
        return Ok(theme);
    }
    [HttpPut]
     public async Task<IActionResult> UpdateTheme(NewThemeContent newTheme)
    {
        var userId=1;
        var theme = await _themeService.UpdateTheme(userId,newTheme);
       
        return Ok(theme);
    }
   
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllThemesBySubjectId(int id)
    {
        var themes = await _themeService.GetAllThemesBySubjectIdAsync(id);
        return Ok(themes);
    }
    [HttpGet("Content/{id}")]
    public async Task<IActionResult> GetAllContentByThemesId(int id)
    {
        var themes = await _themeService.GetContentByThemeIdAsync(id);
        return Ok(themes);
    }
    [HttpPost("ImageUploadContentById/{id}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadImageByContentId(int id,IFormFile file)
    {
        var img = await _themeService.UploadImage(id,file);
        return Ok(img);
    }
}