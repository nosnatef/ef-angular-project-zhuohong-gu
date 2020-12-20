using HotelManagement.Core.Models.Request;
using HotelManagement.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerService.GetCustomers();
            if (!customers.Any())
            {
                return NotFound("no types found");
            }
            return Ok(customers);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetCustomer")]
        public async Task<ActionResult> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerService.GetCustomer(id);
            return Ok(customer);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            var response = await _customerService.DeleteCustomer(id);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CustomerCreateRequest req)
        {
            var createdCustomer = await _customerService.AddCustomer(req);
            if(createdCustomer == null)
            {
                return BadRequest();
            }
            return CreatedAtRoute("GetCustomer", new { id = createdCustomer.Id }, createdCustomer);
        }
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PatchCustomerAsync(int id, [FromBody] CustomerCreateRequest customer)
        {
            customer.Id = id;
            var updatedCustomer = await _customerService.PatchCustomer(customer);
            return CreatedAtRoute("GetCustomer", new { id = updatedCustomer.Id }, updatedCustomer);
        }
    }
}
