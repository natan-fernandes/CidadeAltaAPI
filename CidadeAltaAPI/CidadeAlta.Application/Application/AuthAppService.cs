using AutoMapper;
using CidadeAlta.Application.DTOs;
using CidadeAlta.Application.Interfaces;
using CidadeAlta.Domain.Interfaces.Services;
using CidadeAlta.Domain.Models;

namespace CidadeAlta.Application.Application;

public class AuthAppService : BaseAppService, IAuthAppService
{
    private readonly IAuthService _authService;

    public AuthAppService(IMapper mapper, IAuthService authService) : base(mapper)
    {
        _authService = authService;
    }

    public string GenerateToken(UserDto user)
    {
        return _authService.GenerateToken(Mapper.Map<User>(user));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}