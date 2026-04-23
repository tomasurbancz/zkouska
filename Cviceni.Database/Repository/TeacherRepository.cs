using Cviceni.Database.Entity;
using Cviceni.Database.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Cviceni.Database.Repository;

public class TeacherRepository : IRepository<TeacherEntity>
{
    private DatabaseContext _context;
    
    public TeacherRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Task<List<TeacherEntity>> GetAll()
    {
        return _context.Teachers
            .Include(teacher => teacher.Subjects)
            .ToListAsync();
    }

    public Task<TeacherEntity?> GetById(Guid id)
    {
        return _context.Teachers
            .Include(teacher => teacher.Subjects)
            .FirstOrDefaultAsync(teacher => teacher.Id == id);
    }

    public Task Create(TeacherEntity entity)
    {
        _context.Teachers.Add(entity);
        return _context.SaveChangesAsync();
    }

    public Task Update(TeacherEntity entity)
    {
        _context.Teachers.Update(entity);
        return _context.SaveChangesAsync();
    }

    public Task Delete(TeacherEntity entity)
    {
        _context.Teachers.Remove(entity);
        return _context.SaveChangesAsync();
    }
}