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
        modelBuilder.Entity<StudentEntity>()
            .HasOne(student => student.Class)
            .WithMany(classEntity => classEntity.Students)
            .HasForeignKey(student => student.ClassEntityId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<TeacherEntity>()
            .HasMany(teacher => teacher.Subjects)
            .WithMany(subject => subject.Teachers)
            .UsingEntity(join => join.ToTable("TeacherSubject"));

        base.OnModelCreating(modelBuilder);
    }
}