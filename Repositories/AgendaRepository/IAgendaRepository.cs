using Devhunt_2024_back.Models;

namespace Devhunt_2024_back.Repositories.AgendaRepository;

public interface IAgendaRepository
{
    public Task<AgendaTask> AddTask(AgendaTask agendaTask);
    public Task<Course> AddCourse(Course course);

    public Task<List<AgendaTask>> GetTasks(string prem, string dern);
    public Task<List<Course>> GetCourses(string prem, string dern);
}