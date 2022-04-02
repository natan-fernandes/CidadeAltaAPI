using CidadeAlta.Application.DTOs;
using CidadeAlta.Application.Responses;

namespace CidadeAlta.Application.Interfaces;

public interface ICriminalCodeAppService : IDisposable
{
    Task<ApiResponse<CriminalCodeDto>> Add(CriminalCodeDto criminalCode);
}