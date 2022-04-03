using CidadeAlta.Application.DTOs;
using CidadeAlta.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CidadeAlta.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IAuthAppService _authAppService;

        public AuthController(IUserAppService userAppService, 
            IAuthAppService authAppService)
        {
            _userAppService = userAppService;
            _authAppService = authAppService;
        }


        /// <summary>
        /// Realiza o login de usuários
        /// </summary>
        /// <param name="model">Objeto contendo usuário e senha</param>
        /// <response code="302">Retorna o objeto do usuário e token bearer</response>
        /// <response code="404">Retorna erro encontrado</response>
        [HttpPost("/login")]
        [ProducesResponseType(StatusCodes.Status302Found, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult<dynamic>> Login([FromBody] UserDto model)
        {
            var user = await _userAppService.Get(model.UserName, model.Password);
            if (user == null)
                return NotFound("Usuário ou senha inválidos");

            var token = _authAppService.GenerateToken(user);

            return new
            {
                user,
                token
            };
        }

        /// <summary>
        /// Registra um usuário no banco de dados
        /// </summary>
        /// <param name="model">Objeto contendo usuário e senha</param>
        /// <response code="201">Retorna o objeto do usuário</response>
        /// <response code="409">Retorna erro se o usuário já estiver cadastrado</response>
        /// <response code="422">Retorna um array com erros de validação</response>
        [HttpPost("/register")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string[]))]
        public async Task<ActionResult<dynamic>> Register([FromBody] UserDto model)
        {
            var response = await _userAppService.Add(model);
            if (response.Dto == null)
                return Conflict("Usuário já registrado");
            if (response.IsValid)
                return Created(string.Empty, response.Dto);
            return UnprocessableEntity(response.Errors);
        }
    }
}
