using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Core.Models.Response
{
    public class RoomTypeResponseModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Rent { get; set; }
    }
}
