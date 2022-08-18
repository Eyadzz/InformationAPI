using Domain;

namespace Application.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category> GetByName(string? categoryName);
}