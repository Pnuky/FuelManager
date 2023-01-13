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

        public void AddRefueling(RefuelingDto refuelingDto)
        {
            var refueling = new Refueling();
            refueling.CarId = refuelingDto.CarId;
            refueling.RefuelingAmount = refuelingDto.RefuelingAmount;
            refueling.Run = refuelingDto.Run;

            _context.Set<Refueling>().Add(refueling);
            _context.SaveChanges();
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
    }
}
