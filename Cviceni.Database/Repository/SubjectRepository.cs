using Cviceni.Database.Entity;
using Cviceni.Database.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Cviceni.Database.Repository;

public class SubjectRepository : IRepository<SubjectEntity>
{
    private DatabaseContext _context;
    
    public SubjectRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Task<List<SubjectEntity>> GetAll()
    {
        return _context.Subjects
            .Include(subject => subject.Teachers)
            .ToListAsync();
    }

    public Task<SubjectEntity?> GetById(Guid id)
    {
        return _context.Subjects
            .Include(subject => subject.Teachers)
            .FirstOrDefaultAsync(subject => subject.Id == id);
    }

    public Task Create(SubjectEntity entity)
    {
        _context.Subjects.Add(entity);
        return _context.SaveChangesAsync();
    }

    public Task Update(SubjectEntity entity)
    {
        _context.Subjects.Update(entity);
        return _context.SaveChangesAsync();
    }

    public Task Delete(SubjectEntity entity)
    {
        _context.Subjects.Remove(entity);
        return _context.SaveChangesAsync();
    }
}