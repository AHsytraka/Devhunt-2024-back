using Devhunt_2024_back.Models;

namespace Devhunt_2024_back.Repositories.ProfRepository;

public interface IProfRepository
{
    public Task AddProfessor(Professor professor);
    public Task<List<Professor>> GetProfessors();
}