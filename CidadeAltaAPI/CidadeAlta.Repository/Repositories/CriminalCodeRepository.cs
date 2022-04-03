using System.Reflection;
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

    public IList<CriminalCode> Get(int page, string? filter = null, string? orderBy = null)
    {
        const int pageSize = 5;
        const StringComparison ignoreCase = StringComparison.InvariantCultureIgnoreCase;

        return Get(x => true, new []{ "Status" })

            .Where(x => filter == null 
                        || x.Name.Contains(filter, ignoreCase)
                        || x.Description.Contains(filter, ignoreCase)
                        || x.Id.ToString().Contains(filter, ignoreCase)
                        || (x.Penalty == null || x.Penalty.ToString()!.Contains(filter, ignoreCase))
                        || (x.PrisonTime == null || x.PrisonTime.ToString()!.Contains(filter, ignoreCase))
                        || x.CreateDate.ToString("O").Contains(filter, ignoreCase)
                        || x.UpdateDate.ToString("O").Contains(filter, ignoreCase)
                        || x.CreateUserId.ToString().Contains(filter, ignoreCase)
                        || x.UpdateUserId.ToString().Contains(filter, ignoreCase)
                        || x.StatusId.ToString().Contains(filter, ignoreCase)
                        || x.Status.Name.Contains(filter, ignoreCase))
            //Não da pra usar new { x.Coluna1, x.Coluna2 }.Any(x => x.Contains(filter)), então tem que colocar esse monte de .Contains() :(

            .OrderBy(x => x.GetType().GetProperty(orderBy ?? string.Empty, 
                BindingFlags.IgnoreCase 
                | BindingFlags.Public 
                | BindingFlags.Instance)?.GetValue(x, null))

            .Skip(page * pageSize).Take(pageSize).ToList();
    }

    public long GetCount()
    {
        return Get(x => true).Count();
    }
}