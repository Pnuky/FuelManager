using FuelManager.Models;
using FuelManager.Models.dtos;
using FuelManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FuelManager.Services
{
    public class AdminService : IAdminService
    {
        private readonly FuelManagerDbContext _context;

        public AdminService(FuelManagerDbContext context)
        {
            _context = context;
        }

        public bool DeleteCar(int id)
        {
            var car = _context.Set<Car>().Include(r=>r.Refuelings).FirstOrDefault(c => c.Id == id);
            _context.Set<Car>().Remove(car);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteUser(int id)
        {
            var user = _context.Set<User>().Include(r => r.Cars).FirstOrDefault(c => c.Id == id);
            if (id != 1)
            {
                foreach (var item in user.Cars)
                {
                    foreach (var item2 in item.Refuelings)
                    {
                        if (item.Id == item2.CarId)
                        {
                            _context.Set<Refueling>().Remove(item2);
                        }
                    }
                    _context.Set<Car>().Remove(item);
                }
                _context.Set<User>().Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<CarDto> GetCars()
        {
            var car = _context.Set<Car>().Include(s=>s.User).ToList();
            var map = car.Select(s => new CarDto
            {
                Brand = s.Brand,
                Model = s.Model,
                User = new UserDto
                {
                    Id = s.UserId,
                    Login = s.User.Login
                },
                FuelType = s.FuelType,
                HP = s.HP,
                
            }).OrderBy(c => c.User.Login);
            return map;
        }

        public int GetRoleId(int id)
        {
            return _context.Set<User>().FirstOrDefault(get => get.Id == id).RoleId;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var user = _context.Set<User>().ToList();
            var map = user.Select(s => new UserDto
            {
                Id = s.Id,
                Login = s.Login,
            });
            return map;
        }
    }
}
