using FuelManager.Models;
using Microsoft.EntityFrameworkCore;
using FuelManager.Models.dtos;

namespace FuelManager
{
    public class FuelManagerDbContext:DbContext
    {
        public FuelManagerDbContext(DbContextOptions<FuelManagerDbContext> options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Refueling> Refueling { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(u => u.Cars)
                .WithOne(u => u.User);

            builder.Entity<Role>()
                .HasMany(u => u.Users)
                .WithOne(u => u.Role);

            builder.Entity<Car>()
                .HasMany(u => u.Refuelings)
                .WithOne(u => u.Car);
        }
    }
}
