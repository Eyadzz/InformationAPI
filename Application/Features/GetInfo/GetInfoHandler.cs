using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.GetInfo;

public class GetInfoHandler : IRequestHandler<GetInfoRequest, Information>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetInfoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Information> Handle(GetInfoRequest request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Information.GetInformationWithCategory(request.Id);
        return result;
    }
}