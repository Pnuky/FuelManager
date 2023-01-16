using FuelManager.Models.dtos;

namespace FuelManager.Services.Interfaces
{
    public interface ILogRegService: IBaseService
    {
        public bool Register(RegisterDto registerDto);
        public bool IsValid(loginDto loginDto);
        public bool Logout(int userId);
        public void LoginHistory(loginDto loginDto);
        
    }

}
