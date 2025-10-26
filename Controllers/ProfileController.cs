using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Opiskelijaportaali.Data;
using Opiskelijaportaali.Models;

namespace Opiskelijaportaali.Controllers
{
    //HUOM. tässä ei ole vielä mahdollisuutta päivittää tai poistaa olemassaolevia profiileja!

    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        // Hakee kaikki profiilit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles()
        {
            var profiles = await _context.Profiles.ToListAsync();
            return Ok(profiles);
        }

        // Lisää uuden profiilin
        [HttpPost]
        public async Task<ActionResult<Profile>> AddProfile(Profile profile)
        {
            // Lisää uuden profiili tietokantaan
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            // Palauttaa lisätyn profiilin
            return CreatedAtAction(nameof(GetProfiles), new { id = profile.Id }, profile);
        }
    }
}


