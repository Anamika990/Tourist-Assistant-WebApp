using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuidAssistant.Models;
using System.Data.Entity;

namespace TouristGuidAssistant.DataContext
{
    public class TouristDbContext:DbContext
    {
        public DbSet<Users> Registrations { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<BookingInfo> BookingInfo { get; set; }
        public DbSet<HireGuide> HireGuides { get; set; }
        public DbSet<Contract> Contract { get; set; }

        

    }
}