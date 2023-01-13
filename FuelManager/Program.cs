using FuelManager;
using FuelManager.Models;
using FuelManager.Services;
using FuelManager.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FuelManagerDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddScoped<ILogRegService, LogRegService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<RolesSeeder>();
builder.Services.AddScoped<ICarServices, CarService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
RoleSeeder();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LogReg}/{action=Login}/{id?}");

app.Run();
void RoleSeeder()
{
    using (var roles = app.Services.CreateScope())
    {
        var rolesScope = roles.ServiceProvider.GetRequiredService<RolesSeeder>();
        rolesScope.DbSeeder();
    } 
}
