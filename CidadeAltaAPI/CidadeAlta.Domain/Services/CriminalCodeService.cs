using CidadeAlta.Domain.Interfaces.Repositories;
using CidadeAlta.Domain.Interfaces.Services;
using CidadeAlta.Domain.Models;

namespace CidadeAlta.Domain.Services;

public class CriminalCodeService : ICriminalCodeService
{
    private readonly ICriminalCodeRepository _criminalCodeRepository;

    public CriminalCodeService(ICriminalCodeRepository criminalCodeRepository)
    {
        _criminalCodeRepository = criminalCodeRepository;
    }

    public Task<CriminalCode> Add(CriminalCode criminalCode)
    {
        criminalCode.CreateUser = new User();
        criminalCode.UpdateUser = new User();
        criminalCode.Status = new Status();

        if (!criminalCode.IsValid)
            return Task.FromResult(criminalCode);

        _criminalCodeRepository.Add(criminalCode);

        return Task.FromResult(criminalCode);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}