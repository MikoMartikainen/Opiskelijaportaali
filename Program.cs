using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Opiskelijaportaali.Data;
using Opiskelijaportaali.Models;

namespace Opiskelijaportaali
{
    //Tämä käynnistää ASP.NET Core -webpalvelimen, mahdollistaa Swaggerin ja määrittelee CORS-säännöty.
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

            // VAATII STOREN, EI VOIDA KÄYTTÄÄ
            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // VAATII STOREN, EI VOIDA KÄYTTÄÄ
            //Identity-määritykset
            //builder.Services.AddDefaultIdentity<Profile>(options =>
            //{
            //    options.SignIn.RequireConfirmedAccount = false;
            //})
            //.AddEntityFrameworkStores<AppDbContext>()
            //.AddDefaultTokenProviders();

            //MVC ja Razor Pages 
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Middleware-putki
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                //app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseCors(policy =>
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader()
            );

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
