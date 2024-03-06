using Devhunt_2024_back.Data;
using Devhunt_2024_back.Models;
using Microsoft.EntityFrameworkCore;

namespace Devhunt_2024_back.Repositories.SubjectRepository;

public class SubjectRepository : ISubjectRepository
{
    private readonly AppDbContext _appDbContext;

    public SubjectRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task AddSubject(Subject subject)
    {
        await _appDbContext.Subjects.AddAsync(subject);
        _appDbContext.SaveChangesAsync();
    }

    public async Task<List<Subject>> GetSubjects()
    {
        var subjectList = await _appDbContext.Subjects.ToListAsync();
        return subjectList ?? throw new NullReferenceException("No subject found");
    }
}