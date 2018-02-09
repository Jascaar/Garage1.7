using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage1._7.Models
{
    public class ParkedVehicle
    {
        public string typeOfVehicle { get; set; }
        public string vehicleRegistrationNumber { get; set; }
        public string color { get; set; }
        public string vehicleModel { get; set; }
        public int numberOfTiresForVehicle { get; set; }

    }
}