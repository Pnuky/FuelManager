using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FuelManager.Models
{
    public class DatabaseSeeder
    {   
        private readonly FuelManagerDbContext fuelManagerDbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        public DatabaseSeeder(FuelManagerDbContext context,IPasswordHasher <User> passwordHasher)
        {
            fuelManagerDbContext = context;
            _passwordHasher = passwordHasher;
        }

        private IEnumerable<Role> RoleSeeder()
        {
            var role = new List<Role>()
            {
                new Role
                {
                    Name = "Admin",

                },
                new Role
                {
                    Name = "User",
                }
            };
            return role;
        }

        private User UserSeeder()
        {
            var user = new User
            {
                Login = "Admin",
                Password = "123",
                RoleId = 1
            };
            var hashPass = _passwordHasher.HashPassword(user, user.Password);
            user.Password = hashPass;
            return user;
        }

        public void DbSeeder()
        {
            if (fuelManagerDbContext.Database.CanConnect())
            {
                if (!fuelManagerDbContext.Roles.Any())
                {
                    var roleseeder = RoleSeeder();
                    fuelManagerDbContext.Roles.AddRange(roleseeder);
                    fuelManagerDbContext.SaveChanges();

                }
                if (!fuelManagerDbContext.Users.Any())
                {
                    var userseeder = UserSeeder();
                    fuelManagerDbContext.Users.Add(userseeder);
                    fuelManagerDbContext.SaveChanges();
                }
            }
        }
    }
}
