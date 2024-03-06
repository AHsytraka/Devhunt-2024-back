using Devhunt_2024_back.Models;

namespace Devhunt_2024_back.Repositories.SubjectRepository;

public interface ISubjectRepository
{
    public Task AddSubject(Subject subject);
    public Task<List<Subject>> GetSubjects();
}