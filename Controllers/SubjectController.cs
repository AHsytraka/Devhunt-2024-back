using Devhunt_2024_back.Models;
using Devhunt_2024_back.Repositories.SubjectRepository;
using Microsoft.AspNetCore.Mvc;

namespace Devhunt_2024_back.Controllers;

[ApiController]
[Route("[controller]")]
public class SubjectController : ControllerBase
{
    private readonly ISubjectRepository _subjectRepository;
    public SubjectController(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }
    
    [HttpPost("AddSubject")]
    public async Task<IActionResult> AddSubject(string libelle, string description, string professors)
    {
        var subject = new Subject
        {
            Libelle = libelle,
            Description = description,
            Professors = professors
        };

        await _subjectRepository.AddSubject(subject);
        
        return Ok(new { message = "Added subject"});
    }

    [HttpGet("GetSubjects")]
    public async Task<IActionResult> GetSubjects()
    {
        var subjectList = await _subjectRepository.GetSubjects();
        return Ok(subjectList);
    }
    
}