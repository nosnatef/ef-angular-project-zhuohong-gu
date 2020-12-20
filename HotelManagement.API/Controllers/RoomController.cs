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
    public class RoomController : ControllerBase
    {

        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _roomService.GetRooms();
            if (!rooms.Any())
            {
                return NotFound("no rooms found");
            }
            return Ok(rooms);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetRoom")]
        public async Task<ActionResult> GetRoomByIdAsync(int id)
        {
            var room = await _roomService.GetRoom(id);
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoomTypeAsync([FromBody] RoomCreateRequest roomType)
        {
            var createdRoom = await _roomService.AddRoom(roomType);
            return CreatedAtRoute("GetRoom", new { id = createdRoom.Id }, createdRoom);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PatchRoomAsync(int id, [FromBody] RoomCreateRequest room)
        {
            room.Id = id;
            var updatedRoom = await _roomService.PatchRoom(room);
            return CreatedAtRoute("GetRoom", new { id = updatedRoom.Id }, updatedRoom);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRoomAsync(int id)
        {
            var response = await _roomService.DeleteRoom(id);
            return Ok(response);
        }
    }
}
