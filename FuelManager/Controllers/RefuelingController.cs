using FuelManager.Models.dtos;
using FuelManager.Services;
using FuelManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FuelManager.Controllers
{
    public class RefuelingController:Controller
    {
        private readonly IRefuelingService _refuelingService;

        public RefuelingController(IRefuelingService refuelingService)
        {
            _refuelingService = refuelingService;
        }

        [HttpGet]
        public  IActionResult GetFuel(int id)
        {
            var getFuel = _refuelingService.GetRefueling(id);
            return View(getFuel);
            
        }

        
        public IActionResult AddFuel(RefuelingDto refuelingDto)
        {
            if (!ModelState.IsValid)
            {
                return View(refuelingDto);
            }
            _refuelingService.AddRefueling(refuelingDto);
            return RedirectToAction("GetFuel");
        }
    }
}