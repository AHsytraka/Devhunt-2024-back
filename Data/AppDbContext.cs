using Devhunt_2024_back.Models;
using Devhunt_2024_back.Models.FileUpload;
using Microsoft.EntityFrameworkCore;

namespace Devhunt_2024_back.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<InterestCategory> InterestCategories { get; set; }
    public DbSet<User> Users { get; set; }
    
    public DbSet<Post> Posts { get; set; }
}