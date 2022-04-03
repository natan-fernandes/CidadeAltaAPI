using CidadeAlta.Domain.Models;

namespace CidadeAlta.Domain.Interfaces.Services;

public interface ICriminalCodeService : IDisposable
{
    Task<CriminalCode> Add(CriminalCode criminalCode);
    Task<CriminalCode?> Edit(CriminalCode criminalCode);
    Task<CriminalCode?> Get(Guid id);
    Task<bool> Remove(Guid id);
}