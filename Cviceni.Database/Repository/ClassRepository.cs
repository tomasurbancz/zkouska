using Cviceni.Database.Entity;
using Cviceni.Database.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Cviceni.Database.Repository;

public class ClassRepository : IRepository<ClassEntity>
{
    private DatabaseContext _context;
    
    public ClassRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Task<List<ClassEntity>> GetAll()
    {
        return _context.Classes.ToListAsync();
    }

    public Task<ClassEntity?> GetById(Guid id)
    {
        return _context.Classes.FindAsync(id).AsTask();
    }

    public Task Create(ClassEntity entity)
    {
        _context.Classes.Add(entity);
        return _context.SaveChangesAsync();
    }

    public Task Update(ClassEntity entity)
    {
        _context.Classes.Update(entity);
        return _context.SaveChangesAsync();
    }

    public Task Delete(ClassEntity entity)
    {
        _context.Classes.Remove(entity);
        return _context.SaveChangesAsync();
    }
}