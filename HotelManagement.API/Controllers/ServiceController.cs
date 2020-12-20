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
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            var services = await _serviceService.GetServices();
            if (!services.Any())
            {
                return NotFound("no services found");
            }
            return Ok(services);
        }

        [HttpGet]
        [Route("{id:int}",Name = "GetService")]
        public async Task<IActionResult> GetServiceByIdAsync(int id)
        {
            var service = await _serviceService.GetService(id);
            return Ok(service);
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceAsync([FromBody] ServiceCreateRequest service)
        {
            var createdService = await _serviceService.AddService(service);
            return CreatedAtRoute("GetService", new { id = createdService.Id }, createdService);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PatchServiceAsync(int id, [FromBody] ServiceCreateRequest service)
        {
            service.Id = id;
            var updatedService = await _serviceService.PatchService(service);
            return CreatedAtRoute("GetService", new { id = updatedService.Id }, updatedService);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteServiceAsync(int id)
        {
            var response = await _serviceService.DeleteService(id);
            return Ok(response);
        }
    }
}
