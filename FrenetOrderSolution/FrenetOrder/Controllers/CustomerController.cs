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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        /// <summary>
        /// Obter cliente pelo identificador
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        /// <response code = "200" > cliente obtido com sucesso!</response>
        /// <response code = "400" > Erro ao obter cliente!</response>
        /// <response code = "401" > Não autenticado!</response>
        /// <response code = "500" > Erro interno ao obter cliente!</response>
        [HttpGet("GetById")]
        public async Task<ActionResult<Customer>> GetById([FromQuery] int id)
        {
            try
            {
                var customer = await _customerService.GetById(id);
                _logger.LogInformation($"Cliente {id} obtido");
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter cliente");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obter todos clientes
        /// </summary>
        /// <response code = "200" > Lista de clientes obtida com sucesso!</response>
        /// <response code = "400" > Erro ao obter clientes!</response>
        /// <response code = "401" > Não autenticado!</response>
        /// <response code = "500" > Erro interno ao obter clientes!</response>
        [HttpGet("Get")]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            try
            {
                var customerList = await _customerService.Get();
                _logger.LogInformation($"Todos clientes obtidos");
                return Ok(customerList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos clientes");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualizar um determinado cliente
        /// </summary>
        /// <param name="id">Identificador do cliente.</param>
        /// <param name="customer">Parametros para alterar</param>
        /// <response code = "200" > Cliente atualizado com sucesso!</response>
        /// <response code = "400" > Erro ao atualizar cliente!</response>
        /// <response code = "401" > Não autenticado!</response>
        /// <response code = "500" > Erro interno ao atualizar cliente!</response>
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromQuery] int id, [FromBody] CustomerInput customer)
        {
            try
            {
                await _customerService.Update(id, customer);
                _logger.LogInformation($"Cliente {id} atualizado");
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao atualizar cliente");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Criar um novo cliente
        /// </summary>
        /// <param name="customer">Parametros para criação de um cliente</param>
        /// <response code = "200" > Cliente criado com sucesso!</response>
        /// <response code = "400" > Erro ao criar cliente!</response>
        /// <response code = "401" > Não autenticado!</response>
        /// <response code = "500" > Erro interno ao criar cliente!</response>
        [HttpPost("Create")]
        public async Task<ActionResult<Customer>> Create(CustomerInput customer)
        {
            try
            {
                var customerResult = await _customerService.Create(customer);
                _logger.LogInformation($"Cliente {customer.Nome} criado");
                return Ok(customerResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar cliente");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remover um determinado cliente
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        /// <response code = "200" > Cliente removido com sucesso!</response>
        /// <response code = "400" > Erro ao remover cliente!</response>
        /// <response code = "401" > Não autenticado!</response>
        /// <response code = "500" > Erro interno ao remover cliente!</response>
        [HttpDelete("Remove")]
        public async Task<ActionResult> Remove([FromQuery] int id)
        {
            try
            {
                await _customerService.Remove(id);
                _logger.LogInformation($"Cliente {id} removido");
                return Ok("Remoção realizada com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao remover cliente");
                return BadRequest(ex.Message);
            }
        }
    }
}
