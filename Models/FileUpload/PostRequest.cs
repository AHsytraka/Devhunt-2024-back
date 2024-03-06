using System.Text.Json.Serialization;

namespace Devhunt_2024_back.Models.FileUpload;

public class PostRequest
{
    public required string InterestName { get; set; }
    public required IFormFile File { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public string? ImagePath { get; set; }
}
