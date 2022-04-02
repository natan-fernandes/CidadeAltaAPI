using CidadeAlta.Domain.Models;

namespace CidadeAlta.Domain.Interfaces.Services;

public interface IAuthService : IDisposable
{
    string GenerateToken(User user);
}