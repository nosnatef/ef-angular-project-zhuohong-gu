using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Core.Models.Response
{
    public class CustomerResponseModel
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public RoomResponseModel Room { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? Checkin { get; set; }
        public int TotalPersons { get; set; }
        public int BookingDays { get; set; }
        public decimal Advance { get; set; }
    }
}
