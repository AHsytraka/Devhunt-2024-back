using System.ComponentModel.DataAnnotations;

namespace Devhunt_2024_back.Models;

public class InterestCategory
{
    [Key]
    public int CategoryId { get; set; }
    public required string CategoryName { get; set; }
}