using FuelManager.Models;
using FuelManager.Models.dtos;
using FuelManager.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

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

            _context.Users.Add(user);
            _context.SaveChanges();
            return true;


        }

    }
}
