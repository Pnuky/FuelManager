using Microsoft.EntityFrameworkCore;

namespace FuelManager.Models
{
    public class RolesSeeder
    {   
        private readonly FuelManagerDbContext fuelManagerDbContext;
        public RolesSeeder(FuelManagerDbContext context)
        {
            fuelManagerDbContext = context;
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
            }
        }
    }
}
