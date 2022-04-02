using CidadeAlta.Application.DTOs;

namespace CidadeAlta.Application.Interfaces;

public interface IAuthAppService : IDisposable
{
    string GenerateToken(UserDto user);
}