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
        return _userRepository.Get(userName, password);
    }

    public User? Get(string userName)
    {
        return _userRepository.Get(userName);
    }
    
    public User? Add(User user)
    {
        user.Password = HashPassword(user.Password);

        return _userRepository.Get(user.UserName) == null 
            ? _userRepository.Add(user) 
            : null;
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