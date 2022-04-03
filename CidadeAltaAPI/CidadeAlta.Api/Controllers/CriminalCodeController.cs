using CidadeAlta.Application.DTOs;
using CidadeAlta.Application.Interfaces;
using CidadeAlta.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CidadeAlta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class CriminalCodeController : ControllerBase
    {
        private readonly ICriminalCodeAppService _criminalCodeAppService;

        public CriminalCodeController(ICriminalCodeAppService criminalCodeAppService)
        {
            _criminalCodeAppService = criminalCodeAppService;
        }

        /// <summary>
        /// Obtém todos os códigos penais.
        /// </summary>
        /// <param name="page">Número da página. O total de itens por página é 5</param>
        /// <param name="filter">Filtro para qualquer coluna do banco. (opcional)</param>
        /// <param name="orderBy">Coluna do banco para ordenar. (opcional)</param>
        /// <response code="200">Retorna os códigos penais</response>
        [HttpGet("/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiPageResponse<CriminalCodeDto>>> GetAll(int page = 0, string? filter = null, string? orderBy = null)
        {
            return Ok(await _criminalCodeAppService.Get(page, filter, orderBy));
        }


        /// <summary>
        /// Obtem um código penal
        /// </summary>
        /// <param name="id">Id do código penal</param>
        /// <response code="200">Retorna o código penal</response>
        /// <response code="404">Retorna null se não foi encontrado</response>
        [HttpGet("/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CriminalCodeDto?>> Get(Guid id)
        {
            var criminalCode = await _criminalCodeAppService.Get(id);
            if (criminalCode != null)
                return Ok(criminalCode); //Não tem o found?
            return NotFound(criminalCode);
        }

        /// <summary>
        /// Cria um novo código penal
        /// </summary>
        /// <param name="model">Objeto contendo informações do código penal</param>
        /// <response code="201">Retorna o código penal criado</response>
        /// <response code="422">Retorna um array de erros</response>
        [Authorize]
        [HttpPost("/add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<ApiResponse<CriminalCodeDto>>> Add(CriminalCodeDto model)
        {
            var response = await _criminalCodeAppService.Add(model);
            if (response.IsValid)
                return Created(string.Empty, response.Dto);
            return UnprocessableEntity(response.Errors);
        }

        /// <summary>
        /// Edita um código penal
        /// </summary>
        /// <param name="model">Código penal com o Id desejado</param>
        /// <response code="200">Retorna o código penal editado</response>
        /// <response code="404">Retorna null se o código penal não foi encontrado</response>
        /// <response code="422">Retorna um array com erros</response>
        [Authorize]
        [HttpPatch("/edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<ApiResponse<CriminalCodeDto>>> Edit(CriminalCodeDto model)
        {
            var response = await _criminalCodeAppService.Edit(model);
            if (response?.Dto == null)
                return NotFound(null);
            if (response.IsValid)
                return Ok(response.Dto);
            return UnprocessableEntity(response.Errors);
        }

        /// <summary>
        /// Remove um código penal
        /// </summary>
        /// <param name="id">Id do código penal</param>
        /// <response code="200">Retorna true se foi deletado</response>
        /// <response code="404">Retorna false se não foi encontrado</response>
        [Authorize]
        [HttpDelete("/remove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> Remove(Guid id)
        {
            var response = await _criminalCodeAppService.Remove(id);
            if (response)
                return Ok(response);
            return NotFound(response);
        }
    }
}
