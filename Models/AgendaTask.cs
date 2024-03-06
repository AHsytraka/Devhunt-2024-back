using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Devhunt_2024_back.Models;

public class AgendaTask
{
    [Key]
    public int TaskId { get; set; }
    public required string TaskDescription { get; set; }
    public required string TaskDate { get; set; }
    public required TimeOnly TaskStart { get; set; }
    public required TimeOnly TaskEnd { get; set; }
    
    public required string Matricule { get; set; }
    [ForeignKey("Matricule")]
    [JsonIgnore]
    public User? User { get; set; }
}