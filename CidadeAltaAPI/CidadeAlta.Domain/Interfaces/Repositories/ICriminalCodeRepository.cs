using CidadeAlta.Domain.Models;

namespace CidadeAlta.Domain.Interfaces.Repositories;

public interface ICriminalCodeRepository : IDisposable
{
    CriminalCode? Add(CriminalCode criminalCode);
    CriminalCode? Edit(CriminalCode criminalCode);
    CriminalCode? Get(Guid id);
    bool Remove(CriminalCode criminalCode);
}