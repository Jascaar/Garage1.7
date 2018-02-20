using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Garage1._7.Models
{
    public class GarageContext:DbContext
    {
        public GarageContext() : base("name=GarageContext")
        {
        }

        public DbSet<Member> Members { get; set; }

        public DbSet<VehicleType> VehicleTypes { get; set; }

        public DbSet<ParkedVehicle> ParkedVehicles { get; set; }
    }
}
