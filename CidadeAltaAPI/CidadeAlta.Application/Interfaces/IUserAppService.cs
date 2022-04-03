using CidadeAlta.Application.DTOs;
using CidadeAlta.Application.Responses;

namespace CidadeAlta.Application.Interfaces;

public interface IUserAppService : IDisposable
{
    Task<ApiResponse<UserDto>> Add(UserDto user);

    Task<UserDto?> Get(string userName, string password);
}