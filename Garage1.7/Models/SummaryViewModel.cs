using Garage1._7.Models;

namespace Garage1._7.Models
{
    public class SummaryViewModel
    {
        public TypeOfVehicle Name { get; set; }

        public int Count { get; set; }

        public int SumTires { get; set; }

        public int? ParkingTime { get; set; }

        public int? AccumulatedRevenue { get; set; }
    }
}