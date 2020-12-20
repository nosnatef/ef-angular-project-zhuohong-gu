using HotelManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Core.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public bool Status { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
