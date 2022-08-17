namespace Application.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> Create(T entity);
    Task<T> Get(int id);
}