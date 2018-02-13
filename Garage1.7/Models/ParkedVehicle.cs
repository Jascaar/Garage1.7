﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage1._7.Models
{
    public class ParkedVehicle
    {
        // enum clas

       
        public int Id { get; set; }
        
        public int ParkingSlot { get; set; }

        [DisplayName("Vehicle type")]
        //[Range(1, int.MaxValue, ErrorMessage = "Select type of vehicle to search")]
        public TypeOfVehicle TypeOfVehicle { get; set; }
        [DisplayName("Registration number")]
        //regex validation
        public string VehicleRegistrationNumber { get; set; }
        [DisplayName("Brand")]
        public string VehicleBrand { get; set; }
        [DisplayName("Color")]
        public ConsoleColor Color { get; set; }
        [DisplayName("Number of wheels")]
        [Range (0,10, ErrorMessage = "You need to pick tires between 0-10")]
        public int TiresOnVehicle { get; set; }

        [DisplayName("Parking start time")]
        public DateTime StartParking { get; set; }
      
    }
    public enum TypeOfVehicle
    {
        Car,
        Motorcycle,
        Bus,
        Boat ,
        Airplane,
        Bicycle 

    }

}