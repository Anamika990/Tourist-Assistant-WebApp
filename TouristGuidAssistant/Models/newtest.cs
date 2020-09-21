using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TouristGuidAssistant.Models
{
    public class newtest
    {
        public string destinationTo { get; set; }

        public string destinationFrom { get; set; }
        [Key]
        public int tripNumber { get; set; }
    }
}