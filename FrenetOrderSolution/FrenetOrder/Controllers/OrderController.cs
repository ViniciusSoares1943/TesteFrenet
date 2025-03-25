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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IShippingService _shippingService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService orderService, IShippingService shippingService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _shippingService = shippingService;
            _logger = logger;
        }

        /// <summary>
        /// Obter pedido pelo identificador
        /// </summary>
        /// <param name="id">Identificador do pedido</param>
        /// <response code = "200" > Pedido obtido com sucesso!</response>
        /// <response code = "400" > Erro ao obter pedido!</response>
        /// <response code = "401" > Não autenticado!</response>
        /// <response code = "500" > Erro interno ao obter pedido!</response>
        [HttpGet("GetById")]
        public async Task<ActionResult<Order>> GetById([FromQuery] int id)
        {
            try
            {
                var order = await _orderService.GetById(id);
                _logger.LogInformation($"Pedido {id} obtido");
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter pedido");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obter todos pedidos
        /// </summary>
        /// <response code = "200" > Lista de pedidos obtida com sucesso!</response>
        /// <response code = "400" > Erro ao obter pedidos!</response>
        /// <response code = "401" > Não autenticado!</response>
        /// <response code = "500" > Erro interno ao obter pedidos!</response>
        [HttpGet("Get")]
        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {
                var orderList = await _orderService.Get();
                _logger.LogInformation("Todos pedidos obtidos");
                return Ok(orderList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter pedidos");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualizar um determinado pedido
        /// </summary>
        /// <param name="id">Identificador do pedido</param>
        /// <param name="order">Parametros a serem atualizados no pedido</param>
        /// <response code = "200" > Pedido atualizado com sucesso!</response>
        /// <response code = "400" > Erro ao atualizar pedido!</response>
        /// <response code = "401" > Não autenticado!</response>
        /// <response code = "500" > Erro interno ao atualizar pedido!</response>
        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromQuery] int id, [FromBody] OrderUpdateInput order)
        {
            try
            {
                await _orderService.Update(id, order);
                _logger.LogInformation($"Pedido {id} atualizado");
                return Ok("Atualização realizada com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar pedido");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Criar um novo pedido
        /// </summary>
        /// <param name="order">Parametros de criação de pedido</param>
        /// <response code = "200" > Pedido criado com sucesso!</response>
        /// <response code = "400" > Erro ao criar pedido!</response>
        /// <response code = "401" > Não autenticado!</response>
        /// <response code = "500" > Erro interno ao criar pedido!</response>
        [HttpPost("Create")]
        public async Task<ActionResult<Order>> Create([FromBody] OrderInput order)
        {
            try
            {
                var orderResult = await _orderService.Create(order);
                _logger.LogInformation($"Pedido criado");
                return Ok(orderResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar pedido");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remover um determinado pedido
        /// </summary>
        /// <param name="id">Identificador do pedido</param>
        /// <response code = "200" > Pedido removido com sucesso!</response>
        /// <response code = "400" > Erro ao remover pedido!</response>
        /// <response code = "401" > Não autenticado!</response>
        /// <response code = "500" > Erro interno ao remover pedido!</response>
        [HttpDelete("Remove")]
        public async Task<ActionResult> Remove([FromQuery] int id)
        {
            try
            {
                await _orderService.Remove(id);
                _logger.LogInformation($"Pedido {id} removido");
                return Ok("Remoção realizada com sucesso!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao remover pedido");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Calcular custos de frete (api externa)
        /// </summary>
        /// <param name="input">Parametros para calculo de frete</param>
        /// <response code = "200" > Frete calculado com sucesso!</response>
        /// <response code = "400" > Erro ao calcular frete!</response>
        /// <response code = "401" > Não autenticado!</response>
        /// <response code = "500" > Erro interno ao calcular frete!</response>
        [HttpPost("ShippingCalculate")]
        public async Task<ActionResult<List<ShippingSevices>>> ShippingCalculate([FromBody] ShippingCalculateInput input)
        {
            try
            {
                var result = await _shippingService.ShippingCalculate(input);
                _logger.LogInformation($"Frete calculado");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao calcular frete");
                return BadRequest(ex.Message);
            }
        }
    }
}
