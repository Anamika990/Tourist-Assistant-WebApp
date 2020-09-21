using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TouristGuidAssistant.Models
{
    public class BookingInfo
    {
        [Key]
        public int BookingId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string TravelarGroupName { get; set; }
        public string DestinationForm { get; set; }
        public string DestinationTo { get; set; }

    }
}