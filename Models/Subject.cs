using System.ComponentModel.DataAnnotations;

namespace Devhunt_2024_back.Models;

public class Subject
{
    [Key]
    public int SubjectId { get; set; }
    public required string Libelle { get; set; }
    public required string Description { get; set; }
    public required string Professors { get; set; }
}