using CidadeAlta.Domain.Enums;
using CidadeAlta.Domain.Interfaces.Repositories;
using CidadeAlta.Domain.Interfaces.Services;
using CidadeAlta.Domain.Models;
using Microsoft.AspNetCore.Http;
using Status = CidadeAlta.Domain.Enums.Status;

namespace CidadeAlta.Domain.Services;

public class CriminalCodeService : ICriminalCodeService
{
    private readonly ICriminalCodeRepository _criminalCodeRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserService _userService;

    public CriminalCodeService(ICriminalCodeRepository criminalCodeRepository, 
        IHttpContextAccessor httpContextAccessor, 
        IUserService userService)
    {
        _criminalCodeRepository = criminalCodeRepository;
        _httpContextAccessor = httpContextAccessor;
        _userService = userService;
    }

    public Task<CriminalCode> Add(CriminalCode criminalCode)
    {
        var user = _userService.Get(_httpContextAccessor.HttpContext!.User.Identity!.Name!)!;

        criminalCode.CreateUserId = user.Id;
        criminalCode.UpdateUserId = user.Id;
        criminalCode.StatusId = (int)Status.WaitingForApproval;

        if (!criminalCode.IsValid)
            return Task.FromResult(criminalCode);

        _criminalCodeRepository.Add(criminalCode);

        criminalCode.Status = new Models.Status
        {
            Id = (int)Status.WaitingForApproval,
            Name = EnumHelper.GetEnumDescription(Status.WaitingForApproval)
        };

        return Task.FromResult(criminalCode);
    }

    public Task<CriminalCode?> Edit(CriminalCode criminalCode)
    {
        var dBmodel = _criminalCodeRepository.Get(criminalCode.Id);
        if (dBmodel == null)
            return Task.FromResult(dBmodel);

        var user = _userService.Get(_httpContextAccessor.HttpContext!.User.Identity!.Name!)!;

        criminalCode.CreateDate = dBmodel.CreateDate;
        criminalCode.CreateUserId = dBmodel.CreateUserId;
        dBmodel = criminalCode;
        dBmodel.UpdateUserId = user.Id;
        dBmodel.UpdateDate = DateTime.UtcNow;
        dBmodel.Status = new Models.Status
        {
            Id = criminalCode.StatusId,
            Name = EnumHelper.GetEnumDescription((Status)criminalCode.StatusId)
        };

        if (!dBmodel.IsValid)
            return Task.FromResult(dBmodel)!;

        _criminalCodeRepository.Edit(dBmodel);

        return Task.FromResult(dBmodel)!;
    }

    public Task<CriminalCode?> Get(Guid id)
    {
        return Task.FromResult(_criminalCodeRepository.Get(id));
    }

    public Task<bool> Remove(Guid id)
    {
        var criminalCode = _criminalCodeRepository.Get(id);
        return Task.FromResult(criminalCode != null 
                               && _criminalCodeRepository.Remove(criminalCode));
    }

    public void Dispose()
    {
        _userService.Dispose();
        _criminalCodeRepository.Dispose();

        GC.SuppressFinalize(this);
    }
}