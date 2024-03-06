using Devhunt_2024_back.Models;
using Microsoft.EntityFrameworkCore;

namespace Devhunt_2024_back.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<InterestCategory> InterestCategories { get; set; }
}