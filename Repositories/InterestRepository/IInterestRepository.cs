using Devhunt_2024_back.Models;

namespace Devhunt_2024_back.Repositories.InterestRepository;

public interface IInterestRepository
{
   //Category
   Task<InterestCategory> AddInterestCat(InterestCategory interestCategory);
   Task<List<InterestCategory>> GetInterestCats();
   
   //Interest
   Task<Interest> AddInterest(Interest interest);
   Task<List<Interest>> GetInterests();
   public Task<List<Interest>> GetInterestByCategoryId(int categoryId);
   
   //user
   public Task<List<UserInterest>> GetUserInterest(string matricule);
   public Task<List<UserInterestCategory>> GetUserInterestCategory(string matricule);
   public Task AddInterestToUser(string userMatricule, int interestId);
   public Task AddInterestCategoryToUser(string userMatricule, int catId);
}