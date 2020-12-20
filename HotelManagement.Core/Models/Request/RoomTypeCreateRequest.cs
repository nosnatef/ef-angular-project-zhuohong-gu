using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelManagement.Core.Models.Request
{
    public class RoomTypeCreateRequest
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(20)]
        public string Description { get; set; }

        [Range(0,5000000)]
        public decimal? Rent { get; set; }
    }
}
