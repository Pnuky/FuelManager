using FuelManager.Models.dtos;
using FuelManager.Services;
using FuelManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FuelManager.Controllers
{

    public class CarController:Controller
    {
        private readonly ICarServices _carService;
        public CarController(ICarServices carService)
        {
            _carService = carService;
        }
        public IActionResult GetAllCarRecords()
        {
            TempData["IdHolder"] = _carService.GetRoleId(LogRegController.userId);
            var carRecord = _carService.ShowAllCars(LogRegController.userId);
            return View(carRecord);
        }

        public IActionResult SaveCars(CarDto carDto)
        {
            TempData["IdHolder"] = _carService.GetRoleId(LogRegController.userId);
            if (!ModelState.IsValid)
            {
                return View(carDto);
            }
            _carService.PostCar(carDto, LogRegController.userId);
            return RedirectToAction("GetAllCarRecords");
        }
    }
}
