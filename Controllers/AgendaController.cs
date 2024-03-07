using Devhunt_2024_back.Models;
using Devhunt_2024_back.Repositories.AgendaRepository;
using Devhunt_2024_back.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Devhunt_2024_back.Controllers;

[ApiController]
[Route("[controller]")]
public class AgendaController : ControllerBase
{
    private readonly IAgendaRepository _agendaRepository;
    private readonly JwtService _jwtService;

    public AgendaController(IAgendaRepository agendaRepository, JwtService jwtService)
    {
        _agendaRepository = agendaRepository;
        _jwtService = jwtService;
    }
    
    [HttpPost("AddTask")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> AddTask(string description, DateOnly date, TimeOnly start, TimeOnly end)
    {
        var jwt = Request.Cookies["jwt"];
        
        // Parse the issuer from the JWT as an integer
        var token = _jwtService.Checker(jwt);
        if (token == null)
        {
            return Unauthorized(new { message = "Invalid token" });
        }
        var matricule = token.Issuer;
        
            // Parsing succeeded, you can use the date variable here
            var task = new AgendaTask
            {
                TaskDescription = description,
                TaskDate = date.ToString("dd/MM/yyyy"),
                TaskStart = start,
                TaskEnd = end,
                Matricule = matricule
            };

        var aTask = await _agendaRepository.AddTask(task);
        return Ok(aTask);
    }
    
    [HttpPost("AddCourse")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddCourse(string matiere,string description, DateOnly date, TimeOnly start, TimeOnly end, string prof, string parcours,string niveau, string salle, string groupe)
    {
        var course = new Course
        {
            Matiere = matiere,
            TaskDescription = description,
            TaskDate = date.ToString("dd/MM/yyyy"),
            TaskStart = start,
            TaskEnd = end,
            Prof = prof,
            Parcours = parcours,
            Niveau = niveau,
            Salle = salle,
            Groupe = groupe,
        };

        var aCourse = await _agendaRepository.AddCourse(course);
        
        return Ok(aCourse);
    }

    [HttpGet("GetTasks")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> GetTasks(string prem, string dern)
    {
        var taskList = await _agendaRepository.GetTasks(prem, dern);
        
        return Ok(taskList);
    }
    
    [HttpGet("GetCourses")]
    [Authorize(Roles = "User,Admin")]
    public async Task<IActionResult> GetCourses(string prem, string dern)
    {
        var courseList = await _agendaRepository.GetCourses(prem, dern);
        
        return Ok(courseList);
    }
}