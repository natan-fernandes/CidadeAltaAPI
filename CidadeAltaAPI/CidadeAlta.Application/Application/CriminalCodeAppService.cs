using AutoMapper;
using CidadeAlta.Application.DTOs;
using CidadeAlta.Application.Interfaces;
using CidadeAlta.Application.Responses;
using CidadeAlta.Domain.Interfaces.Services;
using CidadeAlta.Domain.Models;

namespace CidadeAlta.Application.Application;

public class CriminalCodeAppService : BaseAppService, ICriminalCodeAppService
{
    private readonly ICriminalCodeService _criminalCodeService;

    public CriminalCodeAppService(IMapper mapper, 
        ICriminalCodeService criminalCodeService) : base(mapper)
    {
        _criminalCodeService = criminalCodeService;
    }

    public async Task<ApiResponse<CriminalCodeDto>> Add(CriminalCodeDto criminalCodeDto)
    {
        var criminalCode = await _criminalCodeService.Add(Mapper.Map<CriminalCode>(criminalCodeDto));

        var response = new ApiResponse<CriminalCodeDto>
        {
            Dto = Mapper.Map<CriminalCodeDto>(criminalCode),
            Errors = criminalCode.Errors
        };
        response.Dto.Status = criminalCode.Status.Name;

        return response;
    }
    
    public async Task<ApiResponse<CriminalCodeDto>?> Edit(CriminalCodeDto criminalCodeDto)
    {
        var criminalCode = await _criminalCodeService.Edit(Mapper.Map<CriminalCode>(criminalCodeDto));

        var response = new ApiResponse<CriminalCodeDto>
        {
            Dto = Mapper.Map<CriminalCodeDto>(criminalCode),
            Errors = criminalCode?.Errors
        };

        return response;
    }

    public Task<bool> Remove(Guid id)
    {
        return _criminalCodeService.Remove(id);
    }

    public async Task<CriminalCodeDto?> Get(Guid id)
    {
        return Mapper.Map<CriminalCodeDto>(await _criminalCodeService.Get(id));
    }

    public async Task<ApiPageResponse<CriminalCodeDto>> Get(int page, string? filter = null, string? orderBy = null)
    {
        var criminalCodes = await _criminalCodeService.Get(page, out var totalCount, filter, orderBy);

        return new ApiPageResponse<CriminalCodeDto>
        {
            Items = Mapper.Map<IList<CriminalCodeDto>>(criminalCodes),
            TotalCount = totalCount
        };
    }

    public void Dispose()
    {
        _criminalCodeService.Dispose();

        GC.SuppressFinalize(this);
    }
}