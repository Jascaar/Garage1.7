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
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage1._7.DataAcessLayer.RegisterVehicleContext context)
        { context.Garage.AddOrUpdate(e => e.Id,
               new Models.ParkedVehicle {
                   ParkingSlot = 1,
                   TypeOfVehicle = Models.TypeOfVehicle.Car,
                   VehicleBrand = "Volvo",
                   VehicleModel = "Amazon",
                   VehicleRegistrationNumber = "SKG 665",
                   Color = ConsoleColor.Blue,
                   TiresOnVehicle = 4,
                   StartParking = DateTime.Now
    },

                new Models.ParkedVehicle {
                    ParkingSlot = 2,
                    TypeOfVehicle = Models.TypeOfVehicle.Car,
                    VehicleBrand = "Volkswagen",
                    VehicleModel = "Amazon",
                    VehicleRegistrationNumber = "SST 666",
                    Color = ConsoleColor.Red,
                    TiresOnVehicle = 4,
                    StartParking = DateTime.Now
},

                new Models.ParkedVehicle {
                    ParkingSlot = 3,
                    TypeOfVehicle = Models.TypeOfVehicle.Car,
                    VehicleBrand = "Opel",
                    VehicleModel = "Opera",
                    VehicleRegistrationNumber = "DER 359",
                    Color = ConsoleColor.Yellow,
                    TiresOnVehicle = 4,
                    StartParking = DateTime.Now },

                new Models.ParkedVehicle {
                    ParkingSlot = 4,
                    TypeOfVehicle = Models.TypeOfVehicle.Car,
                    VehicleBrand = "Audi",
                    VehicleModel = "Fredag",
                    VehicleRegistrationNumber = "FRE 088 ",
                    Color = ConsoleColor.Blue,
                    TiresOnVehicle = 4,
                    StartParking = DateTime.Now },

                new Models.ParkedVehicle
                {
                    ParkingSlot = 5,
                    TypeOfVehicle = Models.TypeOfVehicle.Car,
                    VehicleBrand = "Audi",
                    VehicleModel = "Corolla",
                    VehicleRegistrationNumber = "KIN 092 ",
                    Color = ConsoleColor.Green,
                    TiresOnVehicle = 4,
                    StartParking = DateTime.Now
                },

                new Models.ParkedVehicle
                {
                    ParkingSlot = 6,
                    TypeOfVehicle = Models.TypeOfVehicle.Boat,
                    VehicleBrand = "Volvo",
                    VehicleModel = "Penta",
                    VehicleRegistrationNumber = "KIN 091 ",
                    Color = ConsoleColor.Green,
                    TiresOnVehicle = 0,
                    StartParking = DateTime.Now
                },

                new Models.ParkedVehicle
                {
                    ParkingSlot = 7,
                    TypeOfVehicle = Models.TypeOfVehicle.Car,
                    VehicleBrand = "Audi",
                    VehicleModel = "Amazon",
                    VehicleRegistrationNumber = "KIN 090 ",
                    Color = ConsoleColor.Green,
                    TiresOnVehicle = 4,
                    StartParking = DateTime.Now
                }


              );


        }
    }
}