using CidadeAlta.Domain.Interfaces.Repositories;
using CidadeAlta.Domain.Models;

namespace CidadeAlta.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(CidadeAltaContext cidadeAltaContext) 
        : base(cidadeAltaContext) { }

    public User? Get(string username, string password)
    {
        return Get(x => x.UserName == username 
                        && x.Password == password).FirstOrDefault();
    }
    
    public User? Get(string username)
    {
        return Get(x => x.UserName == username).FirstOrDefault();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}