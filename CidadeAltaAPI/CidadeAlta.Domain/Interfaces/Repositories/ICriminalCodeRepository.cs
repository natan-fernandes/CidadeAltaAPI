using CidadeAlta.Domain.Models;

namespace CidadeAlta.Domain.Interfaces.Repositories;

public interface ICriminalCodeRepository : IDisposable
{
    CriminalCode? Add(CriminalCode criminalCode);
    CriminalCode? Edit(CriminalCode criminalCode);
    bool Remove(CriminalCode criminalCode);

    long GetCount();
    CriminalCode? Get(Guid id);
    IList<CriminalCode> Get(int page, string? filter = null, string? orderBy = null);
}