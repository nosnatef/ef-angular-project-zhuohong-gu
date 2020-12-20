using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Core.Models.Request
{
    public class RoomCreateRequest
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public bool Status { get; set; }
    }
}
