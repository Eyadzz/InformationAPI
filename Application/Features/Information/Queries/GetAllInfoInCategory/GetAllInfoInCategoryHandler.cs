using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.GetAllInfoInCategoryQuery;

public class GetAllInfoInCategoryHandler : IRequestHandler<GetAllInfoInCategoryRequest, List<string>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInfoInCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<string>> Handle(GetAllInfoInCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.Categories.GetByName(request.CategoryName);
        
        if (category == null)
            throw new Exception("Could not find category with the given name");
        
        var infos = _unitOfWork.Information.GetByCategory(category.CategoryId);

        return infos!;
    }
}