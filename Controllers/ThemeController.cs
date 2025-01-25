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

    [HttpPost]
     public async Task<IActionResult> AddTheme(NewThemeContent newTheme)
    {
        var userId=1;
        var theme = await _themeService.CreateTheme(userId,newTheme);
       
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
    
    
}