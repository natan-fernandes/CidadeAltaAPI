using AutoMapper;
using CidadeAlta.Application.DTOs;
using CidadeAlta.Domain.Models;

namespace CidadeAlta.Application.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CriminalCodeDto, CriminalCode>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
    }
}