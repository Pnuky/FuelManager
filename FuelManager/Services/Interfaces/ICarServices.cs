using FuelManager.Models.dtos;

namespace FuelManager.Services.Interfaces
{
    public interface ICarServices:IBaseService
    {
        public IEnumerable<CarDto> ShowAllCars(int userId);

        public void PostCar(CarDto carSender, int userId);
        
    }
}
