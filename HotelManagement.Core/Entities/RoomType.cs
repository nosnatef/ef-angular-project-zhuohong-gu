using System;
using System.Collections.Generic;

namespace HotelManagement.Core.Entities
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Rent { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
