using AutoMapper;
using CidadeAlta.Application.DTOs;
using CidadeAlta.Domain.Models;

namespace CidadeAlta.Application.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ShouldMapProperty = arg => arg.GetMethod!.IsPublic || arg.GetMethod.IsAssembly;
        CreateMap<CriminalCodeDto, CriminalCode>().ReverseMap();
        CreateMap<StatusDto, Status>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
    }
}