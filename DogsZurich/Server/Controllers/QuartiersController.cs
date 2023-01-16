using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DogsZurich.Server;
using DogsZurich.Shared;

namespace DogsZurich.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuartiersController : ControllerBase
    {
        private readonly DogContext _context;

        public QuartiersController(DogContext context)
        {
            _context = context;
        }

        // GET: api/Quartiers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quartier>>> GetQuartier()
        {
            return await _context.Quartier.ToListAsync();
        }

        // GET: api/Quartiers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quartier>> GetQuartier(int id)
        {
            var quartier = await _context.Quartier.FindAsync(id);

            if (quartier == null)
            {
                return NotFound();
            }

            return quartier;
        }

        // PUT: api/Quartiers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuartier(int id, Quartier quartier)
        {
            if (id != quartier.Id)
            {
                return BadRequest();
            }

            _context.Entry(quartier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuartierExists(id))
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

        // POST: api/Quartiers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quartier>> PostQuartier(Quartier quartier)
        {
            _context.Quartier.Add(quartier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuartier", new { id = quartier.Id }, quartier);
        }

        // DELETE: api/Quartiers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuartier(int id)
        {
            var quartier = await _context.Quartier.FindAsync(id);
            if (quartier == null)
            {
                return NotFound();
            }

            _context.Quartier.Remove(quartier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuartierExists(int id)
        {
            return _context.Quartier.Any(e => e.Id == id);
        }
    }
}
