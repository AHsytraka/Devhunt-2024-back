using Devhunt_2024_back.Data;
using Devhunt_2024_back.Models;
using Microsoft.EntityFrameworkCore;

namespace Devhunt_2024_back.Repositories.InterestRepository;

public class InterestRepository:IInterestRepository
{
    private readonly AppDbContext _appDbContext;

    public InterestRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    //Categories
    public async Task<InterestCategory> AddInterestCat(InterestCategory interestCategory)
    {
        await _appDbContext.InterestCategories.AddAsync(interestCategory);
        await _appDbContext.SaveChangesAsync();
        return interestCategory;
    }

    public async Task<List<InterestCategory>> GetInterestCats()
    {
        var interestCategories = await _appDbContext.InterestCategories.ToListAsync();
        return interestCategories ?? throw new NullReferenceException("Interest category list not found");
    }

    public InterestCategory GetCategoryById(int catId)
    {
        return _appDbContext.InterestCategories
            .Where(c => c.CategoryId == catId)
            .FirstOrDefault();
    }
        
    //Interests
    public async Task<Interest> AddInterest(Interest interest)
    {
        await _appDbContext.Interests.AddAsync(interest);
        await _appDbContext.SaveChangesAsync();
        return interest;
    }

    public async Task<List<Interest>> GetInterests()
    {
        var interests = await _appDbContext.Interests.ToListAsync();
        return interests ?? throw new NullReferenceException("Interest list not found");
    }

    public async Task<List<Interest>> GetInterestByCategoryId(int categoryId)
    {
        return await _appDbContext.Interests.Where(i => i.CategoryId == categoryId).ToListAsync();
    }

    public async Task<Interest> GetInterestById(int interestId)
    {
        var inter = await _appDbContext.Interests.FirstOrDefaultAsync(i => i.InterestId == interestId);

        return inter;
    }
    
    //Add to user
    public async Task AddInterestToUser(string userMatricule, int interestId)
    {
        var inter = await GetInterestById(interestId);

        // Add the new interest to the user's list
        var interest = new UserInterest
        {
            InterestId = inter.InterestId,
            InterestDescription = inter.InterestDescription,
            ImagePath = inter.ImagePath,
            CategoryId = inter.CategoryId,
            Matricule = userMatricule,
            InterestName = inter.InterestName
        };
        _appDbContext.UserInterests.Add(interest);

        // Save the changes to the database
        await _appDbContext.SaveChangesAsync();
    }

    public async Task AddInterestCategoryToUser(string userMatricule, int catId)
    {
        var cat = GetCategoryById(catId);
        var uCategory = new UserInterestCategory
        {
            CategoryId = cat.CategoryId,
            CategoryName = cat.CategoryName,
            Matricule = userMatricule
        };
        // Add the new interest category to the user's list
        _appDbContext.UserInterestCategories.Add(uCategory);

        // Save the changes to the database
        _appDbContext.SaveChanges();
    }

    public async Task<List<UserInterest>> GetUserInterest(string matricule)
    {
        var userInterest = await _appDbContext.UserInterests
            .Where(u => u.Matricule == matricule)
            .ToListAsync();
        return userInterest;
    }

    public async Task<List<UserInterestCategory>> GetUserInterestCategory(string matricule)
    {
        var userIntCat = await _appDbContext.UserInterestCategories
            .Where(u => u.Matricule == matricule)
            .ToListAsync();
        return userIntCat;
    }
}