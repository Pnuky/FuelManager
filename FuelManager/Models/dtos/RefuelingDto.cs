namespace FuelManager.Models.dtos
{
    public class RefuelingDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int Run { get; set; }
        public double RefuelingAmount { get; set; }
        public double?  Compsuption { get; set; }
        public string Description { get; set; }
    }
}
