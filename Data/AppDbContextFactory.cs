using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Opiskelijaportaali.Data
{
    // Tämä luokka tarvitaan, jotta EF Core-migraatioihin
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Lukee sovelluksen asetukset appsettings.json-tiedostosta.
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // My-SQL tietokannan käyttäminen
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36)));

            //Uuden AppDbContext palautus
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}




