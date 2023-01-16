using FuelManager.Models.dtos;

namespace FuelManager.Services.Interfaces
{
    public interface IAdminService:IBaseService
    {
        public bool DeleteCar(int id);

        public bool DeleteUser(int id);

        public IEnumerable<CarDto> GetCars();

        public IEnumerable<UserDto> GetUsers();
    
    }
}
