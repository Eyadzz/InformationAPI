using Application.DTOs;
using Domain;
using MediatR;

namespace Application.Features.GetInfo;

public class GetInfoRequest : IRequest<InfoDTO>
{
    public int Id { get; set; }
}