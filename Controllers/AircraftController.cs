using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using app.Models;

namespace app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly AircraftContext _context;

        public AircraftController(AircraftContext context)
        {
            _context = context;
        }

        // GET: api/aircraft
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aircraft>>> GetItems()
        {
            if (_context.Aircrafts == null)
            {
                return NotFound();
            }
            return await _context.Aircrafts.ToListAsync();
        }

        // GET: api/aircraft/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aircraft>> GetAircraft(long id)
        {
            if (_context.Aircrafts == null)
            {
                return NotFound();
            }
            var aircraft = await _context.Aircrafts.FindAsync(id);

            if (aircraft == null)
            {
                return NotFound();
            }

            return aircraft;
        }

        // PUT: api/aircraft/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAircraft(long id, Aircraft aircraft)
        {
            if (id != aircraft.RegistrationNumber)
            {
                return BadRequest();
            }

            _context.Entry(aircraft).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AircraftExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/aircraft
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aircraft>> PostAircraft(Aircraft aircraft)
        {
            if (_context.Aircrafts == null)
            {
                return Problem("Entity set 'AircraftContext.Items'  is null.");
            }
            _context.Aircrafts.Add(aircraft);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAircraft", new { id = aircraft.RegistrationNumber }, aircraft);
        }

        // DELETE: api/aircraft/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAircraft(long id)
        {
            if (_context.Aircrafts == null)
            {
                return NotFound();
            }
            var aircraft = await _context.Aircrafts.FindAsync(id);
            if (aircraft == null)
            {
                return NotFound();
            }

            _context.Aircrafts.Remove(aircraft);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AircraftExists(long id)
        {
            return (_context.Aircrafts?.Any(e => e.RegistrationNumber == id)).GetValueOrDefault();
        }
    }
}
