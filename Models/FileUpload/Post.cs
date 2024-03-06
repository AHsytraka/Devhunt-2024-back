using System.ComponentModel.DataAnnotations;

namespace Devhunt_2024_back.Models.FileUpload;

public class Post
{
    [Key]
    public int Id { get; set; }
    [MaxLength(255)]
    
    public string InterestName { get; set; }
    public string? Imagepath { get; set; }
    public DateTime Ts { get; set; }
    // public bool Published { get; set; }
}
