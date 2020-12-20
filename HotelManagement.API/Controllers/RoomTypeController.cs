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
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoomTypes()
        {
            var types = await _roomTypeService.GetRoomTypes();
            if (!types.Any())
            {
                return NotFound("no types found");
            }
            return Ok(types);
        }

        [HttpGet]
        [Route("{id:int}",Name = "GetRoomType")]
        public async Task<ActionResult> GetRoomTypeByIdAsync(int id)
        {
            var roomType = await _roomTypeService.GetRoomType(id);
            return Ok(roomType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoomTypeAsync([FromBody] RoomTypeCreateRequest roomType)
        {
            var createdRoomType = await _roomTypeService.AddRoomType(roomType);
            return CreatedAtRoute("GetRoomType", new { id = createdRoomType.Id }, createdRoomType);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PatchRoomTypeAsync(int id,[FromBody] RoomTypeCreateRequest roomType)
        {
            roomType.Id = id;
            var updatedRoomType = await _roomTypeService.PatchRoomType(roomType);
            return CreatedAtRoute("GetRoomType", new { id = updatedRoomType.Id }, updatedRoomType);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRoomTypeAsync(int id)
        {
            var response = await _roomTypeService.DeleteRoomType(id);
            return Ok(response);
        }
    }
}
