using System.IO;
using Microsoft.EntityFrameworkCore;
using robot_generator.Models;

namespace robot_generator.Data;

public class RobotDbContext: DbContext
{
    
    public DbSet<Robot> Robots { get; set; } 
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.db");
        optionsBuilder.UseSqlite($"Data Source={path}");
    }
}