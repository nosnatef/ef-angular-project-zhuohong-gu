using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Core.Models.Response
{
    public class RoomResponseModel
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public RoomTypeResponseModel RoomType { get; set; }
        public bool Status { get; set; }
        public IEnumerable<ServiceResponseModel> Services { get; set; }
    }
}
