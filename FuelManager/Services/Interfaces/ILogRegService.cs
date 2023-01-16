using FuelManager.Models.dtos;

namespace FuelManager.Services.Interfaces
{
    public interface ILogRegService
    {
        public bool Register(RegisterDto registerDto);
        public bool IsValid(loginDto loginDto);
        public bool Logout(int userId);
        public void LoginHistory(loginDto loginDto);
        public int GetRoleId(int id);
    }

}
