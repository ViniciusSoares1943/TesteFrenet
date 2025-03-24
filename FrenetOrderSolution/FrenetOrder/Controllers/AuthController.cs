using FrenetOrder.Models.Dto;
using FrenetOrder.Models.Entity;
using FrenetOrder.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrenetOrder.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CrateUser")]
        public async Task<ActionResult<User>> CreateUser(UserCreateInput input)
        {
            try
            {
                var user = await _userService.Create(input);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromForm] string login, string senha)
        {
            try
            {
                var token  = await _userService.Login(login, senha);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveUser")]
        [Authorize]
        public async Task<ActionResult> RemoveUser ([FromForm] string login)
        {
            try
            {
                await _userService.Remove(login);

                return Ok("Usuário removido com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
