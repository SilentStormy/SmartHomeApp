
using Infrastructure.Data.Data;
using Infrastructure.Data;
using Core_Domain;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var connectionstring = builder.Configuration.GetConnectionString("Defaultconnection");
builder.Services.AddSingleton(new UserRepository(connectionstring));
builder.Services.AddSingleton(new UserService(connectionstring)); 


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
