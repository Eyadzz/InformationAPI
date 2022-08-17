using Domain;
using MediatR;

namespace Application.Features.GetInfo;

public class GetInfoRequest : IRequest<Information>
{
    public int Id { get; set; }
}