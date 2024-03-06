using Devhunt_2024_back.Data;
using Devhunt_2024_back.Helpers;
using Devhunt_2024_back.Models.FileUpload;

namespace Devhunt_2024_back.Repositories.FileRepository;

public class PostRepository : IPostRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IWebHostEnvironment _environment;

    public PostRepository(AppDbContext appDbContext, IWebHostEnvironment environment)
    {
        _appDbContext = appDbContext;
        _environment = environment;
    }

    public async Task<PostResponse> CreatePostAsync(PostRequest postRequest)
    {
        var post = new Post
        {
            InterestName = postRequest.InterestName,
            Imagepath = postRequest.ImagePath,
            Ts = DateTime.Now,
            // Published = true
        };

        var postEntry = await _appDbContext.Posts.AddAsync(post);

        var saveResponse = await _appDbContext.SaveChangesAsync();

        if (saveResponse < 0)
        {
            return new PostResponse { Success = false, Error = "Issue while saving the post", ErrorCode = "CP01" };
        }

        var postEntity = postEntry.Entity;

        var postModel = new PostModel
        {
            Id = postEntity.Id,
            Ts = postEntity.Ts,
            ImagePath = Path.Combine(postEntity.Imagepath),
        };


        return new PostResponse { Success = true, Post = postModel };

    }

    public async Task SavePostFileAsync(PostRequest postRequest)
    {
        var uniqueFileName = FileHelper.GetUniqueFileName(postRequest.File.FileName);

        if (_environment.WebRootPath == null)
        {
            throw new ArgumentNullException(nameof(_environment.WebRootPath));
        }

        if (uniqueFileName == null)
        {
            throw new ArgumentNullException(nameof(uniqueFileName));
        }

        var uploads = Path.Combine(_environment.WebRootPath, "interests", "image", postRequest.InterestName);

        var filePath = Path.Combine(uploads, uniqueFileName);

        Directory.CreateDirectory(Path.GetDirectoryName(filePath));

        await postRequest.File.CopyToAsync(new FileStream(filePath, FileMode.Create));

        postRequest.ImagePath = filePath;

        return;
    }
}
