using Cviceni.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace Cviceni.Database;

public class DatabaseContext : DbContext
{
    public DbSet<ClassEntity> Classes { get; set; }
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<SubjectEntity> Subjects { get; set; }
    public DbSet<TeacherEntity> Teachers { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Data Source=data.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}