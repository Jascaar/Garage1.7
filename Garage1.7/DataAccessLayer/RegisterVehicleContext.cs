using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Garage1._7.DataAcessLayer
{
    public class RegisterVehicleContext: DbContext
    {
        public RegisterVehicleContext() : base("Garage")
        {

        }
        public DbSet<Models.ParkedVehicle> Garage { get; set; }

        public System.Data.Entity.DbSet<Garage1._7.Models.Member> Members { get; set; }

        public System.Data.Entity.DbSet<Garage1._7.Models.VehicleType> VehicleTypes { get; set; }
    }
}