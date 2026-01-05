//7.CRUD emeliyyatlari edeceyim Modelin Controllerini yaradiram;
//8.Controllerde DB mi tanidib uygun modeli getirib .cshtml fileinda foreachle yazdiriram;READ
//9.Hemin Controllerin birinci Create actionunda Crreate sehifesini(formu) gormek ucun view return edirem;
//10.Ikinci Create actionu Dba post ucundur ve async olmasi ucun typei TASK edirik
//11. VM yaradiriq ve icerisinde teleb olunan proplar
//12. Createin post ve validationlari yixlamasi ucun httppost ve ValidateAntiForgeryToken bildirirem;
//13.create cshtml da asp-validationfor yaziram ki error mesaji gorunsun.


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