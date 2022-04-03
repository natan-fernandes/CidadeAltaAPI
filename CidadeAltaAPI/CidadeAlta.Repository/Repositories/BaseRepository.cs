using System.Linq.Expressions;
using CidadeAlta.Domain.Interfaces.Repositories;
using CidadeAlta.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CidadeAlta.Data.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
{
    private readonly CidadeAltaContext _cidadeAltaContext;

    public BaseRepository(CidadeAltaContext cidadeAltaContext)
    {
        _cidadeAltaContext = cidadeAltaContext;
    }

    public TEntity? Add(TEntity obj)
    {
        _cidadeAltaContext.Entry(obj).State = EntityState.Added;
        return _cidadeAltaContext.SaveChanges() > 0
            ? obj
            : null;
    }

    public TEntity? Edit(TEntity obj)
    {
        _cidadeAltaContext.Entry(obj).State = EntityState.Modified;
        return _cidadeAltaContext.SaveChanges() > 0
            ? obj
            : null;
    }

    public bool Remove(TEntity obj)
    {
        _cidadeAltaContext.Entry(obj).State = EntityState.Deleted;
        return _cidadeAltaContext.SaveChanges() > 0;
    }

    public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, string[]? includes = null)
    {
        var query = GetEntityWithIncludes(includes);
        return query.AsNoTracking().Where(predicate);
    }

    public TEntity? GetById(Guid id, string[]? includes = null)
    {
        return Get(x => x.Id == id, includes).FirstOrDefault();
    }

    private IQueryable<TEntity> GetEntityWithIncludes(IReadOnlyList<string>? includes)
    {
        IQueryable<TEntity> query = _cidadeAltaContext.Set<TEntity>();
        return includes == null
            ? query
            : includes.Aggregate(query, (current, next) => current.Include(next));
    }
}