using System.ComponentModel.DataAnnotations;

namespace Devhunt_2024_back.Models;

public class Admin
{
    [Key]
    public required string Matricule { get; set; }
    
    public required string Role { get; set; }
    public required string Password { get; set; }
}