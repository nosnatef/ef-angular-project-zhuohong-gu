using HotelManagement.Core.Models.Request;
using HotelManagement.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Core.ServiceInterfaces
{
    public interface IRoomTypeService
    {
        Task<IEnumerable<RoomTypeResponseModel>> GetRoomTypes();
        Task<RoomTypeResponseModel> AddRoomType(RoomTypeCreateRequest r);
        Task<RoomTypeResponseModel> GetRoomType(int id);
        Task<RoomTypeResponseModel> PatchRoomType(RoomTypeCreateRequest r);
        Task<RoomTypeResponseModel> DeleteRoomType(int id);
    }
}
