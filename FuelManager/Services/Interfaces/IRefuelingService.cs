using FuelManager.Models.dtos;

namespace FuelManager.Services.Interfaces
{
    public interface IRefuelingService:IBaseService
    {
        public IEnumerable<RefuelingDto> GetRefueling(int id);
        public bool AddRefueling(RefuelingDto refuelingDto, int carId);

    }
}
