using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Devhunt_2024_back.Models;

public class User
{
    [Key]
    [MaxLength(7)]
    public required string Matricule { get; set; }
    
    [MaxLength(250)]
    [MinLength(2)]
    public required string Nom { get; set; }
    
    [MaxLength(250)]
    [MinLength(2)]
    public string? Prenom { get; set; }
    
    [MaxLength(2)]
    public required string Niveau { get; set; }
    
    [MaxLength(5)]
    public required string Parcours { get; set; }
    
    public required string Facebook { get; set; }
    
    [JsonIgnore]
    public string Role { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
}