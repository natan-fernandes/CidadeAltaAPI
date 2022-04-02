using CidadeAlta.Domain.Interfaces.Repositories;
using CidadeAlta.Domain.Models;

namespace CidadeAlta.Data.Repositories;

public class CriminalCodeRepository : BaseRepository<CriminalCode>, ICriminalCodeRepository
{
    public CriminalCodeRepository(CidadeAltaContext cidadeAltaContext) : base(cidadeAltaContext) { }
}