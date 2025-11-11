using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Opiskelijaportaali.Data;
using Opiskelijaportaali.Models;

namespace Opiskelijaportaali
{
    //T채m채 k채ynnist채채 ASP.NET Core -webpalvelimen, mahdollistaa Swaggerin ja m채채rittelee CORS-s채채nn철t.
    public class Program
    {
        public static void Main(string[] args)
        {
var builder = WebApplication.CreateBuilder(args);

            // Palvelut
            builder.Services.AddControllers();
//Yhteys tietokantaan 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36)))
            );
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
//Identity-m狎ritykset
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders(); 

//MVC ja Razor Pages 
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); 

var app = builder.Build();

// Middleware-putki
if (app.Environment.IsDevelopment())
{
                app.UseSwagger();
                app.UseSwaggerUI();
    app.UseMigrationsEndPoint();
}

            app.UseCors(policy =>
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader()
            );
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
            app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
        }
    }
}
