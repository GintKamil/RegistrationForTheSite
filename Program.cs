using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrationSite.Services;

var builder = WebApplication.CreateBuilder(args);

string connection = "User ID=asptest;Password=1234;Host=localhost;Port=5432;Database=registrationDB;Pooling=true";
builder.Services.AddDbContext<DataBaseContext>(options => options.UseNpgsql(connection));

builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
builder.Services.AddScoped(typeof(IHashingService), typeof(HashingService));

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Register}/{action=Register}");

app.Run();
