using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.AddInformation;

public class AddInfoHandler : IRequestHandler<AddInfoRequest, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddInfoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(AddInfoRequest request, CancellationToken cancellationToken)
    {
        Category category = await _unitOfWork.Categories.GetByName(request.CategoryName);
        
        if (category == null)
        {
            throw new Exception("Could not find category with the given name:  " + request.CategoryName);
        }

        Information information = new Information
        {
            Text = request.Text,
            Category = category,
            CategoryId = category.CategoryId
        };
        
        var result = await _unitOfWork.Information.Create(information);
        /*category.Information.Add(result);
        _unitOfWork.Categories.Update(category);*/
        await _unitOfWork.Save();
        
        return result.InformationId;
    }
}