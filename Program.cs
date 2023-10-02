using dotnetApp.Data;
using dotnetApp.Models.Interface;
using dotnetApp.Models.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Veritabanına appsettings.json'dan gerekli parametreleri vererek bağlanır
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));
builder.Services.AddScoped<IYetki,YetkiRepository>();
builder.Services.AddScoped<IGrup,GrupRepository>();
builder.Services.AddScoped<IKullanici,KullaniciRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
