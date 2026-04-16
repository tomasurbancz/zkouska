using Cviceni.Database.Entity;
using Cviceni.Database.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Cviceni.Database.Repository;

public class StudentRepository : IRepository<StudentEntity>
{
    private DatabaseContext _context;
    
    public StudentRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Task<List<StudentEntity>> GetAll()
    {
        return _context.Students.ToListAsync();
    }

    public Task<StudentEntity?> GetById(Guid id)
    {
        return _context.Students.FindAsync(id).AsTask();
    }

    public Task Create(StudentEntity entity)
    {
        _context.Students.Add(entity);
        return _context.SaveChangesAsync();
    }

    public Task Update(StudentEntity entity)
    {
        _context.Students.Update(entity);
        return _context.SaveChangesAsync();
    }

    public Task Delete(StudentEntity entity)
    {
        _context.Students.Remove(entity);
        return _context.SaveChangesAsync();
    }
}