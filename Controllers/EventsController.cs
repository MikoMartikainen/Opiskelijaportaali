using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Opiskelijaportaali.Data;
using Opiskelijaportaali.Models;

namespace Opiskelijaportaali.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EventsController(AppDbContext context) { _context = context; }

        //Hakee tietyn päivämäärän tapahtumat
        [HttpGet("{date}")]
        public async Task<ActionResult<IEnumerable<Event>>> GetByDate(DateTime date)
        {
            return await _context.Events
                .Where(e => e.EventDateTime.Date == date.Date)
                .ToListAsync();
        }

        //Lisää uuden tapahtuman
        [HttpPost]
        public async Task<ActionResult<Event>> AddEvent(Event e)
        {
            _context.Events.Add(e);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByDate), new { date = e.EventDateTime.Date }, e);
        }

        //Poistaa tapahtuman idn perusteella
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var e = await _context.Events.FindAsync(id);
            if (e == null) return NotFound();

            _context.Events.Remove(e);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
