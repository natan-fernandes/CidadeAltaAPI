using CidadeAlta.Domain.Models;

namespace CidadeAlta.Domain.Interfaces.Repositories;

public interface IUserRepository : IDisposable
{
    User? Add(User user);

    User? Get(string userName, string password);
    User? Get(string userName);
}