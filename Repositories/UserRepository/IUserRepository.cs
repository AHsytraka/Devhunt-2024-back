using Devhunt_2024_back.Models;

namespace Devhunt_2024_back.Repositories.UserRepository;

public interface IUserRepository
{
    Task<User> CreateUser(User user);
    User GetUserByMatricule(string matricule);
    Task<List<User>> GetUsersByInterest(int interestId);
    
    Admin GetAdminById(string matricule);
}
