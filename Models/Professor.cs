using System.ComponentModel.DataAnnotations;

namespace Devhunt_2024_back.Models;

public class Professor
{
    [Key]
    public required string Matricule { get; set; }
    public required string Nom { get; set; }
    public string? Prenom { get; set; }
    public List<string> Titre { get; set; }
}