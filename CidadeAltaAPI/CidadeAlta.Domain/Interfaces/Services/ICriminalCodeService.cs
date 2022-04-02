using CidadeAlta.Domain.Models;

namespace CidadeAlta.Domain.Interfaces.Services;

public interface ICriminalCodeService : IDisposable
{
    Task<CriminalCode> Add(CriminalCode criminalCode);
}