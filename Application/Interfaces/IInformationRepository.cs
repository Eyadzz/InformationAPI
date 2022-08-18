using Application.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IInformationRepository : IRepository<Information>
{
    Task<InfoDTO> GetInformationWithCategory(int informationId);
    List<string?> GetByCategory(int categoryId);
}