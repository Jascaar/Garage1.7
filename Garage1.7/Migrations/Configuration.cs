namespace Garage1._7.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    


    internal sealed class Configuration : DbMigrationsConfiguration<Garage1._7.DataAcessLayer.RegisterVehicleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Garage1._7.DataAcessLayer.RegisterVehicleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Garage.AddOrUpdate(e => e.Id,
               new Models.ParkedVehicle { Id = 1, ParkingSlot = 1, TypeOfVehicle = Models.TypeOfVehicle.Car, VehicleBrand = "Volvo", VehicleRegistrationNumber = "s", Color = ConsoleColor.Blue, TiresOnVehicle= 4, StartParking = DateTime.Now}


              );


        }
    }
}
