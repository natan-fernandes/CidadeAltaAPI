using CidadeAlta.Domain.Models;

namespace CidadeAlta.Domain.Interfaces.Services;

public interface IUserService : IDisposable
{
    User? Get(string userName, string password);
    User? Get(string userName);
    User? Add(User user);
}