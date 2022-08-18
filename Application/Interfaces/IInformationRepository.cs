using Domain;

namespace Application.Interfaces;

public interface IInformationRepository : IRepository<Information>
{
    Task<Information> GetInformationWithCategory(int informationId);
    Task<Information> Add(Information information);
    List<string?> GetByCategory(int categoryId);
}