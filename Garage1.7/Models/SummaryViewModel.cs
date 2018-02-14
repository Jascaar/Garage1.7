using Garage1._7.DataAcessLayer;
using Garage1._7.Models;
using System.ComponentModel;

namespace Garage1._7.Models
{
    public class SummaryViewModel
    {
        [DisplayName("Vehicle Type")]
        public TypeOfVehicle Name { get; set; }

        [DisplayName("#Instances")]

        public int Count { get; set; }
        [DisplayName("#Tires")]

        public int SumTires { get; set; }
        [DisplayName("Acc. parking time")]

        public int? ParkingTime { get; set; }
        [DisplayName("Acc. revenue")]

        public int? AccumulatedRevenue { get; set; }

        public string TotalName = "Total";

        public int TotalCount { get; set; }
        public int TotalSumTires
        { get; set; }
        public int? TotalParkingTime
        { get; set; }
        public int? TotalAccumulatedRevenue
        { get; set; }










    }
}