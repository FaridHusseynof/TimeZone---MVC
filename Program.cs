
using Microsoft.EntityFrameworkCore;
using TimeZone.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TimeZoneDbContext>(options =>
{
    options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TimeZone;Trusted_Connection=True;TrustServerCertificate=True;");
});
var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}"
    );

app.Run();