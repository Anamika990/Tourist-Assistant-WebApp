using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TouristGuidAssistant.Models
{
    public class HireGuide
    {
        [Key]
        public int HireID { get; set; }
        [Required(ErrorMessage = "Destination From is required")]
        public string DestinationFrom { get; set; }
        [Required(ErrorMessage = "Destination To is required")]
        public string DestinationTo { get; set; }
        [Required(ErrorMessage = "Day From To is required")]
        public DateTime Day { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string TravlerName { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        


    }
}