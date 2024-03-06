using Devhunt_2024_back.Models.FileUpload;

namespace Devhunt_2024_back.Repositories.FileRepository;

public interface IPostRepository
{
    Task SavePostFileAsync(PostRequest postRequest);
    Task<PostResponse> CreatePostAsync(PostRequest postRequest);
    
}
