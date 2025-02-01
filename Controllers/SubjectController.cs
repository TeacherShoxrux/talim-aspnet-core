using Microsoft.AspNetCore.Mvc;
using Talim.DTOs;
using Talim.Services;

namespace Talim.Controllers;
[ApiController]
[Route("api/[controller]")]
public class SubjectController : ControllerBase
{
    private readonly ISubjectService _subjectService;

    public SubjectController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }
    [HttpPost]
     public async Task<IActionResult> CreateSubject(NewSubject newSubject)
     {
        var userId=1;
        var subject = await _subjectService.CreateSubjectAsync(userId,newSubject);
        return Ok(subject);
     }
     [HttpGet("{id}")]
      public async Task<IActionResult> GetSubjectsByEduDirectionId(int id)
     {
        var subject = await _subjectService.GetSubjectsByEducationDirectionIdAsync(id);
        return Ok(subject);
     }
     [HttpGet("Top/{max}")]
      public async Task<IActionResult> GetTopSubjects(int max=10)
     {
        var subject = await _subjectService.GetTopSubjectsAsync(max);
        return Ok(subject);
     }
}