using Devhunt_2024_back.Data;
using Devhunt_2024_back.Models;

namespace Devhunt_2024_back.Repositories.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
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

}
