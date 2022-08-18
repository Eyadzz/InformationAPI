using Domain;

namespace Application.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    //Task<ICollection<Information>> GetAllInfo(string categoryName);
    Task<Category> GetByName(string? categoryName);

    void Update(Category category);
}