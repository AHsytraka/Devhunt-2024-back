using Devhunt_2024_back.Models;
using Devhunt_2024_back.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Devhunt_2024_back.Repositories.UserRepository;

namespace Devhunt_2024_back.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly JwtService _jwtService;

    public UserController(IUserRepository userRepository, JwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    [HttpPost("Auth/Register")]
    public async Task<IActionResult> Register(string matricule, string nom, string prenom, string niveau,string parcour, string facebook,string password)
    {
        User newUser = new()
        {
            Matricule = matricule,
            Nom = nom,
            Prenom = prenom,
            Niveau = niveau,
            Parcour = parcour,
            Facebook = facebook,
            Role = "User",
            Password = BCrypt.Net.BCrypt.HashPassword(password),
        };
        try
        {
            await _userRepository.CreateUser(newUser);
            return Ok(new { message = "Created"});
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost("Auth/Login")]
    public IActionResult Login(string matricule, string password)
    {
        try {
            var user = _userRepository.GetUserByMatricule(matricule);
            
            if (user.Matricule != matricule)
                return BadRequest("Mot de passe ou matricule invalide");
            if(!BCrypt.Net.BCrypt.Verify(password, user.Password))
                return BadRequest("Mot de passe ou matricule invalide");
            
            var jwt = _jwtService.Generator(user.Matricule, user.Role);
            Response.Cookies.Append("jwt", jwt, new CookieOptions {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            });
            
            return Ok(jwt);

        } catch(Exception e)
        {
            return BadRequest(e);
        }
    }
    
    [HttpGet("GetUser")]
    [Authorize(Roles = "User")]
    public IActionResult GetUser()
    {
        var jwt = Request.Cookies["jwt"];
        
        // Parse the issuer from the JWT as an integer
        var token = _jwtService.Checker(jwt);
        if (token == null)
        {
            return Unauthorized(new { message = "Invalid token" });
        }
        var matricule = token.Issuer;
        var user = _userRepository.GetUserByMatricule(matricule);
        return Ok(user);
    }

    [HttpPost("Logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");
        return Ok( new {message = "success"});
    }
}