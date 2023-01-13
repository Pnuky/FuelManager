using FuelManager.Models.dtos;

namespace FuelManager.Services.Interfaces
{
    public interface IRefuelingService
    {
        public IEnumerable<RefuelingDto> GetRefueling(int id);
        public void AddRefueling(RefuelingDto refuelingDto);
    }
}
