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


        public void PostCar(CarDto carSender)
        {
            var car = new Car();
            car.Brand = carSender.Brand;
            car.HP = carSender.HP;
            car.UserId = 1;
            car.Model = carSender.Model;
            car.FuelType = carSender.FuelType;
            car.UserId = 2;
            _context.Set<Car>().Add(car);
            
            _context.SaveChanges();

        }

        public IEnumerable<CarDto> ShowAllCars()
        {
            var getCar = _context.Set<Car>().Include(s=>s.User).ToList();
            var resultDto = getCar.Select(s => new CarDto
            {
                Brand = s.Brand,
                HP = s.HP,
                UserId = s.UserId,
                Model = s.Model
            });

            return resultDto;
        }

        
    }
}
