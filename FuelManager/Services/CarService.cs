using FuelManager.Models;
using FuelManager.Models.dtos;
using FuelManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FuelManager.Services
{
    public class CarService : ICarServices
    {
        private readonly FuelManagerDbContext _context;
        
        public CarService(FuelManagerDbContext context)
        {
            _context = context;
        }

        public int GetRoleId(int id)
        {
            return _context.Set<User>().FirstOrDefault(get => get.Id == id).RoleId;
        }

        public void PostCar(CarDto carSender, int userId)
        {
            var car = new Car();
            car.Brand = carSender.Brand;
            car.HP = carSender.HP;
            car.UserId = userId;
            car.Model = carSender.Model;
            car.FuelType = carSender.FuelType;
    
            _context.Set<Car>().Add(car);
            
            _context.SaveChanges();

        }

        public IEnumerable<CarDto> ShowAllCars(int userId)
        {
            var getCar = _context.Set<Car>().Include(s=>s.User).Where(u=>u.UserId == userId).ToList();
            var resultDto = getCar.Select(s => new CarDto
            {
                Id = s.Id,  
                Brand = s.Brand,
                HP = s.HP,
                UserId = s.UserId,
                Model = s.Model
            });

            return resultDto;
        }

        
    }
}
