using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Devhunt_2024_back.Models;

public class Course
{
    [Key]
    public int CourseId { get; set; }
    public required string TaskDescription { get; set; }
    public required string TaskDate { get; set; }
    public required TimeOnly TaskStart { get; set; }
    public required TimeOnly TaskEnd { get; set; }
    public required string Matiere { get; set; }
    public required string Prof { get; set; }
    
    public required string Parcours { get; set; }
    public required string Niveau { get; set; }
    public required string Salle { get; set; }
    public required string Groupe { get; set; }
}