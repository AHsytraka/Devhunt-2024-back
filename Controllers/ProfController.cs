using Devhunt_2024_back.Models;
using Devhunt_2024_back.Repositories.ProfRepository;
using Microsoft.AspNetCore.Mvc;

namespace Devhunt_2024_back.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfController : ControllerBase
{
    private readonly IProfRepository _profRepository;

    public ProfController(IProfRepository profRepository)
    {
        _profRepository = profRepository;
    }
    [HttpPost("AddProfessor")]
    public async Task<IActionResult> AddProfessor(string matricule, string nom, string prenom, string titre)
    {
        var Professor = new Professor
        {
            Matricule = matricule,
            Nom = nom,
            Prenom = prenom,
            Titre = titre
        };

        await _profRepository.AddProfessor(Professor);
        return Ok(new { message = "Added professor"});
    }

    [HttpGet("GetProfessors")]
    public async Task<IActionResult> GetProfessors()
    {
        var profList = await _profRepository.GetProfessors();
        return Ok(profList);
    }
}