using CidadeAlta.Domain.Models;

namespace CidadeAlta.Domain.Interfaces.Services;

public interface IUserService : IDisposable
{
    User? Add(User user);

    User? Get(string userName);
    User? Get(string userName, string password);
}