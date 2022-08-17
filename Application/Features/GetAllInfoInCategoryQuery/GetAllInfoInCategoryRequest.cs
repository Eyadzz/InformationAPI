using Domain;
using MediatR;

namespace Application.Features.GetAllInfoInCategoryQuery;

public class GetAllInfoInCategoryRequest : IRequest<List<string>>
{
    public string? CategoryName { get; set; }
}