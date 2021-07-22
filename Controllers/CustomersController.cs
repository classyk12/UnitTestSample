using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unit_test_sample.Interfaces;
using Unit_test_sample.Models;

namespace Unit_test_sample.Fundamentals
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerService.GetAllAsync());
        }

        [HttpGet("GetCustomer/{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] string id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var count = await _customerService.Find(customer.FirstName);
            if (count > 0)
            {
                return BadRequest(new
                {
                    status = false, 
                    message = $"{customer.FirstName} already exist"
                });
            }
            
            await _customerService.CreateAsync(customer);
            return Ok(customer.Id);
        }

        [HttpPut("UpdateCustomer/{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, Customer customerIn)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _customerService.UpdateAsync(id, customerIn);
            return NoContent();
        }

        [HttpDelete("RemoveCustomer/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _customerService.DeleteAsync(customer.Id);
            return NoContent();
        }
    }
}