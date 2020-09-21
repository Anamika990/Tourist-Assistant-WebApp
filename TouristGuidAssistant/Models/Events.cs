using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TouristGuidAssistant.Models
{
    public class Events
    {
       [Key]
        public int EventId { get; set; }
        public string EventType { get; set; }
        public string DestinationForm { get; set; }
        public string DestinationTo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public string Details { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public string Travelgroup { get; set; }






    }
}