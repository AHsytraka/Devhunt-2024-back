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
    
    public string ImagePath { get; set; }
    
    public int CategoryId { get; set; }
    
    [ForeignKey(("CategoryId"))]
    [JsonIgnore]
    public InterestCategory? InterestCategory { get; set; }
}

public class UserInterest
{
    [Key]
    public int  InterestId { get; set; }
    
    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    public required string InterestName { get; set; }
    
    public required string InterestDescription { get; set; }
    
    public string ImagePath { get; set; }
    
    public int CategoryId { get; set; }
    
    [ForeignKey(("CategoryId"))]
    [JsonIgnore]
    public InterestCategory? InterestCategory { get; set; }}