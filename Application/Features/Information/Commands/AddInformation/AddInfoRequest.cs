using Domain;
using MediatR;

namespace Application.Features.AddInformation;

public class AddInfoRequest: IRequest<int>
{
    public string? Text { get; set; }
    public string? CategoryName { get; set; }
}