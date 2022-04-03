using CidadeAlta.Domain.Models;

namespace CidadeAlta.Domain.Interfaces.Services;

public interface ICriminalCodeService : IDisposable
{
    Task<CriminalCode> Add(CriminalCode criminalCode);
    Task<CriminalCode?> Edit(CriminalCode criminalCode);
    Task<bool> Remove(Guid id);

    Task<CriminalCode?> Get(Guid id);
    Task<IList<CriminalCode>> Get(int page, out long totalCount, string? filter = null, string? orderBy = null);
}