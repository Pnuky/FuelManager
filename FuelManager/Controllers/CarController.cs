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
            var carRecord = _carService.ShowAllCars();
            return View(carRecord);
        }

        public IActionResult SaveCars(CarDto carDto)
        {
            if (!ModelState.IsValid)
            {
                return View(carDto);
            }
            _carService.PostCar(carDto);
            return RedirectToAction("GetAllCarRecords");
        }
    }
}
