using System.Security.Cryptography;
using System.Text;
using CidadeAlta.Domain.Interfaces.Repositories;
using CidadeAlta.Domain.Interfaces.Services;
using CidadeAlta.Domain.Models;

namespace CidadeAlta.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User? Get(string userName, string password)
    {
        password = HashPassword(password);
        var user = _userRepository.Get(userName, password);
        if (user is not null) //Ninguém precisa saber o hash da senha do usuário né?
            user.Password = string.Empty;

        return user;
    }

    public User? Get(string userName)
    {
        var user = _userRepository.Get(userName);
        if (user is not null) //Ninguém precisa saber o hash da senha do usuário né?
            user.Password = string.Empty;

        return user;
    }
    
    public User? Add(User user)
    {
        if (!user.IsValid)
            return user;

        user.Password = HashPassword(user.Password);

        var addedUsed = _userRepository.Get(user.UserName) is null
            ? _userRepository.Add(user)
            : null;

        return addedUsed;
    }

    private static string HashPassword(string password)
    {
        using var hashAlgorithm = SHA512.Create();
        var byteValue = Encoding.UTF8.GetBytes(password);
        var byteHash = hashAlgorithm.ComputeHash(byteValue);
        return Convert.ToHexString(byteHash);
    }

    public void Dispose()
    {
        _userRepository.Dispose();
        GC.SuppressFinalize(this);
    }
}