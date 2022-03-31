using System.Linq.Expressions;

namespace CidadeAlta.Domain.Interfaces.Repositories;

public interface IBaseRepository<T>
{
    T? Add(T obj);
    T? Edit(T obj);

    IEnumerable<T> Get(Expression<Func<T, bool>> predicate, string[]? includes = null);
}