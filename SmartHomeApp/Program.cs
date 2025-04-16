
using Infrastructure.Data;
using Core_Domain.Interface;
using Infrastructure.Data.Interfaces;
using Core_Domain.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IUserserivce,UserService>();
builder.Services.AddScoped<IUserRepository,UserRepository>(); 
builder.Services.AddScoped<IDeviceRepository,DeviceRpository>(); 
builder.Services.AddScoped<IDeviceService,DeviceService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
