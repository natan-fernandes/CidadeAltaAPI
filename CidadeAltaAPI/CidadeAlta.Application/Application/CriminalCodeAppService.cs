using System.Transactions;
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
    public CriminalCodeAppService(IMapper mapper, ICriminalCodeService criminalCodeService) : base(mapper)
    {
        _criminalCodeService = criminalCodeService;
    }

    public async Task<ApiResponse<CriminalCodeDto>> Add(CriminalCodeDto criminalCodeDto)
    {
        //using (var transaction = new cidadealtacon)
        //{

        //    scope.Complete();
        //}

        var criminalCode = await _criminalCodeService.Add(Mapper.Map<CriminalCode>(criminalCodeDto));

        var response = new ApiResponse<CriminalCodeDto>
        {
            Dto = Mapper.Map<CriminalCodeDto>(criminalCode),
            Errors = criminalCode.Errors
        };

        return response;
    }

    public void Dispose()
    {
        _criminalCodeService.Dispose();

        GC.SuppressFinalize(this);
    }
}