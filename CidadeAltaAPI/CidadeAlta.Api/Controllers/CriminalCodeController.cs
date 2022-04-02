using CidadeAlta.Application.DTOs;
using CidadeAlta.Application.Interfaces;
using CidadeAlta.Application.Responses;
using CidadeAlta.Domain.Interfaces.Services;
using CidadeAlta.Domain.Validators;
using Microsoft.AspNetCore.Mvc;

namespace CidadeAlta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriminalCodeController : ControllerBase
    {
        private readonly ICriminalCodeAppService _criminalCodeAppService;

        public CriminalCodeController(ICriminalCodeAppService criminalCodeAppService)
        {
            _criminalCodeAppService = criminalCodeAppService;
        }

        [HttpPost("/add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<ApiResponse<CriminalCodeDto>>> Add(CriminalCodeDto model)
        {
            var response = await _criminalCodeAppService.Add(model);
            if (response.IsValid)
                return Ok(response.Dto);
            return UnprocessableEntity(response.Errors);
        }
    }
}
