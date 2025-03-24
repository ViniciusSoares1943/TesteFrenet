using FrenetOrder.Models.Dto;
using FrenetOrder.Models.Entity;
using FrenetOrder.Service;
using FrenetOrder.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrenetOrder.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IShippingService _shippingService;

        public OrderController(IOrderService orderService, IShippingService shippingService)
        {
            _orderService = orderService;
            _shippingService = shippingService;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Order>> GetById([FromQuery] int id)
        {
            try
            {
                var order = await _orderService.GetById(id);

                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {
                var orderList = await _orderService.Get();

                return Ok(orderList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromQuery] int id, [FromBody] OrderUpdateInput order)
        {
            try
            {
                await _orderService.Update(id, order);

                return Ok("Atualização realizada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Order>> Create([FromBody] OrderInput order)
        {
            try
            {
                var orderResult = await _orderService.Create(order);

                return Ok(orderResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Remove")]
        public async Task<ActionResult> Remove([FromQuery] int id)
        {
            try
            {
                await _orderService.Remove(id);

                return Ok("Remoção realizada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ShippingCalculate")]
        public async Task<ActionResult<string>> ShippingCalculate()
        {
            try
            {
                var result = await _shippingService.Calculate();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
