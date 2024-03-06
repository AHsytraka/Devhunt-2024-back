using Devhunt_2024_back.Data;
using Devhunt_2024_back.Models;
using Microsoft.EntityFrameworkCore;

namespace Devhunt_2024_back.Repositories.ProfRepository;

public class ProfRepository : IProfRepository
{
    private readonly AppDbContext _appDbContext;

    public ProfRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task AddProfessor(Professor professor)
    {
        await _appDbContext.Professors.AddAsync(professor);
        _appDbContext.SaveChangesAsync();
    }

    public async Task<List<Professor>> GetProfessors()
    {
        var profList =await _appDbContext.Professors.ToListAsync();
        return profList ?? throw new NullReferenceException("No professor found");
    }
}