using FuelManager.Models.dtos;

namespace FuelManager.Services.Interfaces
{
    public interface ICarServices
    {
        public IEnumerable<CarDto> ShowAllCars();

        public void PostCar(CarDto carSender);
        
    }
}
