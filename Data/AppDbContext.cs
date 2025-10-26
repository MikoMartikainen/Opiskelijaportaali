using Microsoft.EntityFrameworkCore;
using Opiskelijaportaali.Models;

namespace Opiskelijaportaali.Data
{
    //Hallinnoi tietokannan tauluja
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; } //Tapahtumat
        public DbSet<Profile> Profiles { get; set; } //Käyttäjäprofiilit
    }
}

