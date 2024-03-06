using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Devhunt_2024_back.Models;

public class InterestCategory
{
    [Key]
    public int CategoryId { get; set; }
    public required string CategoryName { get; set; }
}

public class UserInterestCategory
{
    [Key]
    public int UCategoryId { get; set; }
    public int CategoryId { get; set; }
    public required string CategoryName { get; set; }
    
    public string Matricule { get; set; } 
    [ForeignKey("Matricule")]
    [JsonIgnore]
    public User User { get; set; }
}