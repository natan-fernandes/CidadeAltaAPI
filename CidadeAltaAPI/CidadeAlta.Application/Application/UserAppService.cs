using AutoMapper;
using CidadeAlta.Application.DTOs;
using CidadeAlta.Application.Interfaces;
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
        var user = Mapper.Map<UserDto>(_userService.Get(userName, password));
        if (user != null)
            user.Password = string.Empty;
        return Task.FromResult(user);
    }

    public Task<UserDto?> Get(string userName)
    {
        var user = Mapper.Map<UserDto>(_userService.Get(userName));
        if (user != null)
            user.Password = string.Empty;
        return Task.FromResult(user);
    }

    public Task<UserDto?> Add(UserDto user)
    {
        var userDto = Mapper.Map<UserDto>(_userService.Add(Mapper.Map<User>(user)));
        if (userDto != null)
            userDto.Password = string.Empty;
        return Task.FromResult(userDto);
    }

    public void Dispose()
    {
        _userService.Dispose();
        GC.SuppressFinalize(this);
    }
}