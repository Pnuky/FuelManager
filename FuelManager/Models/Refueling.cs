using System.Net.NetworkInformation;

namespace FuelManager.Models
{
    public class Refueling
    {
        public int Id { get; set; }
        public int Run { get; set; }
        public double RefuelingAmount { get; set; }
        public double?  Compsumption { get; set; }
        public Car Car { get; set; }
        public  int CarId { get; set; }

    }
}
