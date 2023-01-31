namespace aspnet_core_boilerplate_code_first.Repositories;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
    T Insert(T entity);
    void Update(T entity);
    void Delete(int id);
    void Delete(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> InsertAsync(T entity);
    Task DeleteAsync(int id);
    
}