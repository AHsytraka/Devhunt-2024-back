using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devhunt_2024_back.Models;

public class Interest
{
    [Key]
    public int  InterestId { get; set; }
    public required string InterestName { get; set; }
    
    public int CategoryId { get; set; }
    [ForeignKey(("CategoryId"))]
    public InterestCategory InterestCategor { get; set; }
}