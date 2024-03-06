using System.ComponentModel.DataAnnotations;

namespace Devhunt_2024_back.Models;

public class Course : AgendaTask
{
    public required string Matiere { get; set; }
    public required string Prof { get; set; }
    
    public required string Parcours { get; set; }
    public required string Niveau { get; set; }
    public required string Salle { get; set; }
    public required string Groupe { get; set; }
}