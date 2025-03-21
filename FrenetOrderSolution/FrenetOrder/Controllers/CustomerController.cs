using FrenetOrder.Models.Entity;
using FrenetOrder.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrenetOrder.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controlller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Customer>> GetById([FromQuery] int id)
        {
            try
            {
                var customer = await _customerService.GetById(id);

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            try
            {
                var customerList = await _customerService.Get();

                return Ok(customerList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromQuery] int id, [FromBody] Customer customer)
        {
            try
            {
                await _customerService.Update(id, customer);

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("Create")]
        public async Task<ActionResult<Customer>> Create(Customer customer)
        {
            try
            {
                var customerResult = await _customerService.Create(customer);

                return Ok(customerResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
