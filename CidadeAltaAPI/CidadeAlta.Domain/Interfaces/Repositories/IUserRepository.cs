using CidadeAlta.Domain.Models;

namespace CidadeAlta.Domain.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User>, IDisposable
{
    User? Get(string userName, string password);
    User? Get(string userName);
}