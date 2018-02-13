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
               new Models.ParkedVehicle { Id = 1, ParkingSlot = 1, TypeOfVehicle = Models.TypeOfVehicle.Car, VehicleBrand="Volvo", VehicleRegistrationNumber = "SKG 665", Color = ConsoleColor.Blue, TiresOnVehicle= 4, StartParking = DateTime.Now},
                              new Models.ParkedVehicle { Id = 2, ParkingSlot = 2, TypeOfVehicle = Models.TypeOfVehicle.Car, VehicleBrand = "Volkswagen", VehicleRegistrationNumber = "SST 666", Color = ConsoleColor.Red, TiresOnVehicle = 4, StartParking = DateTime.Now },
                                                            new Models.ParkedVehicle { Id = 3, ParkingSlot = 3, TypeOfVehicle = Models.TypeOfVehicle.Car, VehicleBrand = "Opel", VehicleRegistrationNumber = "KGB 359", Color = ConsoleColor.Yellow, TiresOnVehicle = 4, StartParking = DateTime.Now },
                                                                                                                        new Models.ParkedVehicle { Id = 4, ParkingSlot = 4, TypeOfVehicle = Models.TypeOfVehicle.Car, VehicleBrand = "Audi", VehicleRegistrationNumber = "KIN 088 ", Color = ConsoleColor.Green, TiresOnVehicle = 4, StartParking = DateTime.Now }


              );


        }
    }
}
