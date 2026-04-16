namespace Cviceni.Database.Repository.Interface;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAll();
    Task<T?> GetById(Guid id);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}