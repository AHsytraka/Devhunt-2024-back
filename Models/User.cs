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
    public required string Prenom { get; set; }
    
    [StringLength(2)]
    public required string Niveau { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public required string Role { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public required string Password { get; set; }
}