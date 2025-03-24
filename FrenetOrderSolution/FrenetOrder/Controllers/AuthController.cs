using Azure;
using FrenetOrder.Models.Dto;
using FrenetOrder.Models.Entity;
using FrenetOrder.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrenetOrder.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUserService userService, ILogger<AuthController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// Criar um novo usuário
        /// </summary>
        /// <param name="input">Login e senha do usuário a ser criado.</param>
        /// <response code = "200" > Usuário criado com sucesso!</response>
        /// <response code = "400" > Erro ao criar usuário!</response>
        /// <response code = "500" > Erro interno ao criar usuário!</response>
        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public async Task<ActionResult<User>> CreateUser(UserCreateInput input)
        {
            try
            {
                var user = await _userService.Create(input);
                _logger.LogInformation("Usuário criado com sucesso");
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar usuario");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Logar com um usuário e obter o token de autorização.
        /// </summary>
        /// <param name="login">Login do usuário.</param>
        /// <param name="senha">Senha do usuário.</param>
        /// <response code = "200" > Usuário autenticado com sucesso!</response>
        /// <response code = "400" > Erro autenticar usuário!</response>
        /// <response code = "500" > Erro interno ao autenticar usuário!</response>
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromForm] string login, [FromForm] string senha)
        {
            try
            {
                var token = await _userService.Login(login, senha);
                _logger.LogInformation($"Usuário {login} autenticado");
                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao autenticar usuário");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remover usuário (necessário autenticação)
        /// </summary>
        /// <param name="login">Login do usuário</param>
        /// <response code = "200" > Usuário removido com sucesso!</response>
        /// <response code = "400" > Erro ao remover usuário!</response>
        /// <response code = "401" > Não autenticado!</response>
        /// <response code = "500" > Erro interno ao remover usuário!</response>
        [Authorize]
        [HttpDelete("RemoveUser")]
        public async Task<ActionResult> RemoveUser([FromForm] string login)
        {
            try
            {
                await _userService.Remove(login);
                _logger.LogInformation($"Usuário {login} removido");
                return Ok("Usuário removido com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao remover usuário");
                return BadRequest(ex.Message);
            }
        }
    }
}
