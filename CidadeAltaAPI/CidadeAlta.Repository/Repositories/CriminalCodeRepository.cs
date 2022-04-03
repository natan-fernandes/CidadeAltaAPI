using CidadeAlta.Domain.Interfaces.Repositories;
using CidadeAlta.Domain.Models;

namespace CidadeAlta.Data.Repositories;

public class CriminalCodeRepository : BaseRepository<CriminalCode>, ICriminalCodeRepository
{
    public CriminalCodeRepository(CidadeAltaContext cidadeAltaContext) : base(cidadeAltaContext) { }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public CriminalCode? Get(Guid id)
    {
        return Get(x => x.Id == id, new []{ "Status" }).FirstOrDefault();
    }
}