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
    }
}