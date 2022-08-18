using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.AddInformation;

public class AddInfoHandler : IRequestHandler<AddInfoRequest, Information>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddInfoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Information> Handle(AddInfoRequest request, CancellationToken cancellationToken)
    {
        Category category = await _unitOfWork.Categories.GetByName(request.CategoryName);
        
        if (category == null)
        {
            throw new Exception("Could not find category with the given name:  " + request.CategoryName);
        }

        Information information = new Information
        {
            Text = request.Text,
            CategoryId = category.CategoryId
        };
        
        var result = await _unitOfWork.Information.Create(information);

        await _unitOfWork.Save();
        
        return result;
    }
}