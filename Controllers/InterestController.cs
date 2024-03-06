using System.ComponentModel;
using Devhunt_2024_back.Models;
using Devhunt_2024_back.Models.FileUpload;
using Devhunt_2024_back.Repositories.FileRepository;
using Devhunt_2024_back.Repositories.InterestRepository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Devhunt_2024_back.Controllers;

[ApiController]
[Route("[controller]")]
public class InterestController : ControllerBase
{
    private readonly IInterestRepository _interestRepository;
    private readonly IPostRepository _postRepository;

    public InterestController(IInterestRepository interestRepository, IPostRepository postRepository)
    {
        _interestRepository = interestRepository;
        _postRepository = postRepository;
    }
    
    [HttpPost("AddInterestCategory")]
    public IActionResult AddInterestCategory(string categoryName)
    {
        var interestCategory = new InterestCategory
        {
            CategoryName = categoryName
        };
        var intCat = _interestRepository.AddInterestCat(interestCategory);
        return Ok(new { message = "Added category : "+ intCat.Result});
    }

    [HttpGet("GetInterestCategories")]
    public IActionResult GetInterestCategories()
    {
        var intCatList = _interestRepository.GetInterestCats();
        return Ok(intCatList);
    }
    
    [HttpPost("AddInterest")]
    [RequestSizeLimit(25 * 1024 * 1024)] //file size
    public IActionResult AddInterest(string interestName, string interestDescription, int categoryId, [FromForm]PostRequest postRequest)
    {
        //Save image
        if (postRequest == null)
        {
            return BadRequest(new PostResponse { Success = false, ErrorCode = "S01", Error = "Invalid post request" });
        }

        if (string.IsNullOrEmpty(Request.GetMultipartBoundary()))
        {
            return BadRequest(new PostResponse { Success = false, ErrorCode = "S02", Error = "Invalid post header" });
        }


        if (postRequest.File != null)
        {
            _postRepository.SavePostFileAsync(postRequest);
        }

        var postResponse = _postRepository.CreatePostAsync(postRequest);
        
        var interest = new Interest {
            InterestName = interestName,
            InterestDescription = interestDescription,
            CategoryId = categoryId,
            ImagePath = postResponse.Result.Post.ImagePath
        };
        
        var inter = _interestRepository.AddInterest(interest);
        return Ok(new {message = "Added interest : "+ inter});
    }
    

    [HttpGet("GetInterests")]
    public IActionResult GetInterests()
    {
        var interList = _interestRepository.GetInterests();
        return Ok(interList);
    }
}