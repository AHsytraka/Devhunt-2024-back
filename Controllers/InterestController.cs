using System.ComponentModel;
using Devhunt_2024_back.Models;
using Microsoft.AspNetCore.Mvc;

namespace Devhunt_2024_back.Controllers;

[ApiController]
[Route("[controller]")]
public class InterestController : ControllerBase
{
    [HttpPost("AddInterestCategory")]
    public IActionResult AddInterestCategory([FromForm] InterestCategory interestCategory)
    {
        return Ok();
    }
}