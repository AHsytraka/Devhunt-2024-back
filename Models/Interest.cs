using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Devhunt_2024_back.Models;

public class Interest
{
    [Key]
    public int  InterestId { get; set; }
    
    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    public required string InterestName { get; set; }
    
    public required string InterestDescription { get; set; }
    
    public required string WebSite { get; set; }
    
    public string ImagePath { get; set; }
    public int CategoryId { get; set; }
    
    [ForeignKey(("CategoryId"))]
    [JsonIgnore]
    public InterestCategory? InterestCategory { get; set; }
}

public class UserInterest
{
    [Key]
    public int UInterestId { get; set; }
    public int  InterestId { get; set; }
    
    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    public required string InterestName { get; set; }
    
    public required string InterestDescription { get; set; }
    
    public required string WebSite { get; set; }

    
    public string ImagePath { get; set; }
    
    public int CategoryId { get; set; }
    
    public string Matricule { get; set; } 

    [ForeignKey("Matricule")]
    [JsonIgnore]
    public User User { get; set; }
    
    [ForeignKey(("CategoryId"))]
    [JsonIgnore]
    public InterestCategory? InterestCategory { get; set; }}