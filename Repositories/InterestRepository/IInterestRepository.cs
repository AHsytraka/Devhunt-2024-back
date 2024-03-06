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
   
   //add to user
   public Task AddInterestToUser(string userMatricule, UserInterest userInterest);
   public Task AddInterestCategoryToUser(string userMatricule, UserInterestCategory userInterestCategory);
}