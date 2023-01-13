using FuelManager.Models.enums;

namespace FuelManager.Models.dtos
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Consumption { get; set; }
        public int HP { get; set; }
        public int UserId { get; set; }
        public fuelType FuelType { get; set; }
    }
}
