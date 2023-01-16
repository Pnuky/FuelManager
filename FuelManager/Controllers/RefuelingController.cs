using FuelManager.Models.dtos;
using FuelManager.Services;
using FuelManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FuelManager.Controllers
{
    public class RefuelingController:Controller
    {
        private readonly IRefuelingService _refuelingService;
        private static int _carId { get; set; }

        public RefuelingController(IRefuelingService refuelingService)
        {
            _refuelingService = refuelingService;
        }

        public  IActionResult GetFuel(int id)
        {
            _carId = id;
            var getFuel = _refuelingService.GetRefueling(id);
            return View(getFuel);
        }

        public IActionResult AddFuel(RefuelingDto refuelingDto)
        {
            if (!ModelState.IsValid)
            {
                return View(refuelingDto);
            }
            if (_refuelingService.AddRefueling(refuelingDto, _carId))
            {
                ModelState.AddModelError(nameof(refuelingDto.Run), "Run value is lowest tham previous value");
                    return View(refuelingDto);
            }

            return RedirectToAction("GetAllCarRecords", "Car");
        }
    }
}