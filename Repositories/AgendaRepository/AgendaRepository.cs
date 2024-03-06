using System.Globalization;
using Devhunt_2024_back.Data;
using Devhunt_2024_back.Models;
using Microsoft.EntityFrameworkCore;

namespace Devhunt_2024_back.Repositories.AgendaRepository;

public class AgendaRepository : IAgendaRepository
{
    private readonly AppDbContext _appDbContext;

    public AgendaRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<AgendaTask> AddTask(AgendaTask agendaTask)
    {
        await _appDbContext.AgendaTasks.AddAsync(agendaTask);
        _appDbContext.SaveChangesAsync();
        return agendaTask;
    }

    public async Task<Course> AddCourse(Course course)
    {
        await _appDbContext.Courses.AddAsync(course);
        _appDbContext.SaveChangesAsync();
        return course;
    }

    public async Task<List<AgendaTask>> GetTasks(string prem, string dern)
    {
        DateTime startDate, endDate;

        if (!DateTime.TryParseExact(prem, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
        {
            throw new ArgumentException("Invalid start date format. Expected format is dd/MM/yyyy.");
        }

        if (!DateTime.TryParseExact(dern, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
        {
            throw new ArgumentException("Invalid end date format. Expected format is dd/MM/yyyy.");
        }

        var allTasks = await _appDbContext.AgendaTasks.ToListAsync();

        return allTasks
            .Where(t => DateTime.ParseExact(t.TaskDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) >= startDate 
                        && DateTime.ParseExact(t.TaskDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) <= endDate)
            .ToList();
    }

    public async Task<List<Course>> GetCourses(string prem, string dern)
    {       DateTime startDate, endDate;

        if (!DateTime.TryParseExact(prem, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
        {
            throw new ArgumentException("Invalid start date format. Expected format is dd/MM/yyyy.");
        }

        if (!DateTime.TryParseExact(dern, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
        {
            throw new ArgumentException("Invalid end date format. Expected format is dd/MM/yyyy.");
        }
        
        var allCourse = await _appDbContext.Courses.ToListAsync();

        return allCourse
            .Where(c => DateTime.ParseExact(c.TaskDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) >= startDate 
                        && DateTime.ParseExact(c.TaskDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) <= endDate)
            .ToList();
    }
}