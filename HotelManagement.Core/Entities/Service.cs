using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Core.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime? ServiceDate { get; set; }
    }
}
