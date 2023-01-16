using FuelManager.Controllers;
using FuelManager.Models;
using FuelManager.Models.dtos;
using FuelManager.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace FuelManager.Services
{
    public class LogRegService : ILogRegService
    {
        private readonly FuelManagerDbContext _context;
        private readonly IPasswordHasher <User> _passwordHasher;
        public LogRegService(FuelManagerDbContext context, IPasswordHasher <User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        //Walidacja
        public bool IsValid(loginDto loginDto)
        {

            var getUser = _context.Set<User>().FirstOrDefault(get => get.Login == loginDto.Login);
            if (getUser == null)
            {
                return false;
            }
            var getPass = _passwordHasher.VerifyHashedPassword(getUser,getUser.Password,loginDto.Password);
            if (getPass == PasswordVerificationResult.Success && getUser.Login == loginDto.Login)
            {
                LogRegController.userId = getUser.Id;
                return true;
            }
            return false;
        }

        public bool Logout(int userId)
        {
            throw new NotImplementedException();
        }

        public bool Register(RegisterDto registerDto)
        {
            var user = new User();
            user.Login = registerDto.Login;
            user.Password = registerDto.Password;
            var hashPass = _passwordHasher.HashPassword(user, user.Password);
            user.Password = hashPass;
            user.RoleId = registerDto.RoleId;

            _context.Set<User>().Add(user);
            _context.SaveChanges();
            return true;


        }

        public void LoginHistory(loginDto loginDto)
        {
            var userName = _context.Set<User>().FirstOrDefault(get => get.Login == loginDto.Login);
            var path = @"C:\Users\Mac\Desktop\PROJEKT_UM\logs.txt";
            StreamWriter sw;
            using (sw = File.AppendText(path))
            {
                sw.WriteLine($"{userName.Login},{DateTime.Now}");
                sw.Close();
            }
            
        }

        public int GetRoleId(int id)
        {
            return _context.Set<User>().FirstOrDefault(get => get.Id == id).RoleId;
        }
    }
}
