using AutoMapper;
using CidadeAlta.Application.DTOs;
using CidadeAlta.Application.Interfaces;
using CidadeAlta.Application.Responses;
using CidadeAlta.Domain.Interfaces.Services;
using CidadeAlta.Domain.Models;

namespace CidadeAlta.Application.Application;

public class UserAppService : BaseAppService, IUserAppService
{
    private readonly IUserService _userService;

    public UserAppService(IMapper mapper, IUserService userService) : base(mapper)
    {
        _userService = userService;
    }

    public Task<UserDto?> Get(string userName, string password)
    {
        return Task.FromResult(Mapper.Map<UserDto?>(_userService.Get(userName, password)));
    }

    public Task<ApiResponse<UserDto>> Add(UserDto user)
    {
        var savedUser = _userService.Add(Mapper.Map<User>(user));

        var response = new ApiResponse<UserDto>
        {
            Dto = Mapper.Map<UserDto?>(savedUser),
            Errors = savedUser?.Errors
        };

        if (response.Dto != null) //Ninguém precisa saber o hash da senha do usuário né?
            response.Dto.Password = string.Empty;

        return Task.FromResult(response);
    }

    public void Dispose()
    {
        _userService.Dispose();
        GC.SuppressFinalize(this);
    }
}