namespace DataAccess;

public interface IRepository<T>
{
    Task<List<T>> GetAll();
    Task<T?> Get(long id);
    Task Add(T task);
    Task Update(long id,T entity);
    Task Delete(long id);
}
