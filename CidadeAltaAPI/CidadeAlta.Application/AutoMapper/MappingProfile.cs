using AutoMapper;
using CidadeAlta.Application.DTOs;
using CidadeAlta.Domain.Models;

namespace CidadeAlta.Application.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ShouldMapProperty = arg => arg.GetMethod!.IsPublic || arg.GetMethod.IsAssembly;
        CreateMap<CriminalCode, CriminalCodeDto>().ForMember(x => x.Status, m => m.MapFrom(a => a.Status.Name));
        CreateMap<CriminalCodeDto, CriminalCode>().ForMember(x => x.Status, m => m.Ignore());
        CreateMap<UserDto, User>().ReverseMap();
    }
}