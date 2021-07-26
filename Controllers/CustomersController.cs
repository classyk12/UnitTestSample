using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<List<CustomerDto>>> GetAll(string searchParam = null)
        {
            var items = await _customerService.GetAllAsync();

            if(!string.IsNullOrEmpty(searchParam))
            {
                items = items.Where(c => c.FirstName.Contains(searchParam, StringComparison.OrdinalIgnoreCase) || 
               c.LastName.Contains(searchParam, StringComparison.OrdinalIgnoreCase) ).ToList();
            }
            return items.Select(c => c.AsDto()).ToList();
        }

        [HttpGet("GetCustomer/{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer([FromRoute] string id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Create([FromBody] Customer customer)
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
            return customer;
        }

        [HttpPut("UpdateCustomer/{id}")]
        public async Task<ActionResult> Update([FromRoute] string id, Customer customerIn)
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
        public async Task<ActionResult> Delete([FromRoute] string id)
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