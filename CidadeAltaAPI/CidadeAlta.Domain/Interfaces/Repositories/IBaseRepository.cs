using System.Linq.Expressions;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMemberInSuper.Global
namespace CidadeAlta.Domain.Interfaces.Repositories;

public interface IBaseRepository<T>
{
    T? Add(T obj);
    T? Edit(T obj);
    bool Remove(T obj);

    IEnumerable<T> Get(Expression<Func<T, bool>> predicate, string[]? includes = null);
    T? GetById(Guid id, string[]? includes = null);
}