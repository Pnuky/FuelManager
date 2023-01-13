﻿using FuelManager.Models.dtos;
using FuelManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;

namespace FuelManager.Controllers
{
    public class LogRegController:Controller
    {
        private readonly ILogRegService _logRegService;
        public LogRegController(ILogRegService logRegService)
        {
            _logRegService = logRegService;
        }

        [HttpPost]
        public IActionResult Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }
            _logRegService.Register(registerDto);
            
            return RedirectToAction("Login");
           
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(loginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (_logRegService.IsValid(loginDto))
            {
                return RedirectToAction("GetAllCarRecords","Car");
            }
            ModelState.AddModelError(nameof(loginDto), "Provided data are incorect");
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
    }
    
}