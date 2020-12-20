using HotelManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Core.RepositoryInterfaces
{
    public interface IRoomTypeRepository : IAsyncRepository<RoomType>
    {
        Task<IEnumerable<RoomType>> GetRoomTypes();
    }
}
