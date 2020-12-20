using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Core.Models.Response
{
    public class ServiceResponseModel
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime? ServiceDate { get; set; }
    }
}
