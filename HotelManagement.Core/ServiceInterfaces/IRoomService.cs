using HotelManagement.Core.Models.Request;
using HotelManagement.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Core.ServiceInterfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomResponseModel>> GetRooms();
        Task<RoomResponseModel> GetRoom(int id);
        Task<RoomResponseModel> AddRoom(RoomCreateRequest r);
        Task<RoomResponseModel> PatchRoom(RoomCreateRequest r);
        Task<RoomResponseModel> DeleteRoom(int id);
        Task<RoomResponseModel> bookRoom(int id);
    }
}
