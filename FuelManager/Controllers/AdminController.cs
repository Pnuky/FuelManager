using FuelManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FuelManager.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService AdminService)
        {
            _adminService = AdminService;
        }

        public IActionResult DeleteCar(int Id)
        {
            TempData["IdHolder"] = _adminService.GetRoleId(LogRegController.userId);
            if (_adminService.DeleteCar(Id))
            {
                return RedirectToAction("GetCar");
            }
            return View();
        }
        
        public IActionResult DeleteUser(int id)
        {
            TempData["IdHolder"] = _adminService.GetRoleId(LogRegController.userId);
            if (_adminService.DeleteUser(id))
            {
                return RedirectToAction("GetUser");
            }
            return View();
        }

        public IActionResult GetCar()
        {
            TempData["IdHolder"] = _adminService.GetRoleId(LogRegController.userId);
            var car = _adminService.GetCars();
            return View(car);
        }

        public IActionResult GetUser()
        {
            TempData["IdHolder"] = _adminService.GetRoleId(LogRegController.userId);
            var user = _adminService.GetUsers();
            return View(user);
        }
    }
}
