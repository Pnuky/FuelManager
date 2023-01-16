using FuelManager.Models;
using FuelManager.Models.dtos;
using FuelManager.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FuelManager.Services
{
    
    public class RefuelService : IRefuelingService
    {
        private readonly FuelManagerDbContext _context;
        


        public RefuelService(FuelManagerDbContext context)
        {
            _context = context;
        }

        public bool AddRefueling(RefuelingDto refuelingDto, int carId)
        {

            var lastValue = _context.Set<Refueling>().Where(x => x.CarId == carId).OrderByDescending(x => x.Id).FirstOrDefault();
            var refueling = new Refueling();

           
                if (lastValue == null)
                {
                    refueling.RefuelingAmount = refuelingDto.RefuelingAmount;
                    refueling.Run = refuelingDto.Run;
                    refueling.CarId = carId;
                    refueling.Compsumption = null;
                    _context.Set<Refueling>().Add(refueling);
                    _context.SaveChanges();
                    return true;
                }
                else if(refuelingDto.Run > lastValue.Run)
                {
                    refueling.RefuelingAmount = refuelingDto.RefuelingAmount;
                    refueling.Run = refuelingDto.Run;
                    refueling.CarId = carId;
                    refueling.Compsumption = refuelingDto.RefuelingAmount / ((refuelingDto.Run - lastValue.Run) / 100d);
                    _context.Set<Refueling>().Add(refueling);
                    _context.SaveChanges();
                    return true;
                }

            
 
            return false;

        }

        public IEnumerable<RefuelingDto> GetRefueling(int id)
        {
            var getRefueling = _context.Set<Refueling>().Where(r => r.CarId == id);
            var result = getRefueling.Select(s => new RefuelingDto
            {
                CarId = s.CarId,
                RefuelingAmount = s.RefuelingAmount,
                Run = s.Run,
                Compsuption = s.Compsumption
            });
            return result;
        }

        public int GetRoleId(int id)
        {
            return _context.Set<User>().FirstOrDefault(get => get.Id == id).RoleId;
        }
    }
}
