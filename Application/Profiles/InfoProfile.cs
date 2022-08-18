using Application.DTOs;
using Application.Features.AddInformation;
using AutoMapper;
using Domain;

namespace Application.Profiles;

public class InfoProfile : Profile
{
    public InfoProfile()
    {
        CreateMap<InfoDTO, Information>()
            .ForMember(
                dest => dest.InformationId,
                opt => opt.MapFrom(src => $"{src.InformationId}")
            ).ForMember(
                dest => dest.Text,
                opt => opt.MapFrom(src => $"{src.Text}")
            ).ForMember(
                dest => dest.CategoryId,
                opt => opt.MapFrom(src => $"{src.CategoryId}")
            )/*.ForMember(
                dest => dest.Category.Name,
                opt => opt.MapFrom(src => $"{src.CategoryName}")
            )*/;
    }
}