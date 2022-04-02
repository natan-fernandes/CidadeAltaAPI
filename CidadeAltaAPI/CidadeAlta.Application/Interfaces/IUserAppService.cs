using CidadeAlta.Application.DTOs;

namespace CidadeAlta.Application.Interfaces;

public interface IUserAppService : IDisposable
{
    Task<UserDto?> Get(string userName, string password);
    Task<UserDto?> Add(UserDto user);
}