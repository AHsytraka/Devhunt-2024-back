using Devhunt_2024_back.Data;
using Devhunt_2024_back.Models;
using Devhunt_2024_back.Repositories.InterestRepository;
using Microsoft.EntityFrameworkCore;

namespace Devhunt_2024_back.Repositories.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IInterestRepository _interestRepository;

    public UserRepository(AppDbContext appDbContext, IInterestRepository interestRepository)
    {
        _interestRepository = interestRepository;
        _appDbContext = appDbContext;
    }

    public async Task<User> CreateUser(User user)
    {
        _appDbContext.Users.Add(user);
        await _appDbContext.SaveChangesAsync();
        return user;
    }

    public User GetUserByMatricule(string matricule)
    {
        var user = _appDbContext.Users.FirstOrDefault(u => u.Matricule == matricule);
        return user ?? throw new NullReferenceException("User not found");
    }

    public async Task<List<User>> GetUsersByInterest(int interestId)
    {
        var matricules = await _appDbContext.UserInterests
            .Where(ui => ui.InterestId == interestId)
            .Select(u => u.Matricule)
            .ToListAsync();

        return await _appDbContext.Users
            .Where(u => matricules.Contains(u.Matricule))
            .ToListAsync();
    }
}
