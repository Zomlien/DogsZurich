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
    public class DogownersController : ControllerBase
    {
        private readonly DogContext _context;

        public DogownersController(DogContext context)
        {
            _context = context;
        }

        // GET: api/Dogowners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dogowner>>> GetDogowner()
        {
            return _context.Dogowner
                .Include(x => x.Sex)
                .Include(q => q.Quartier)
                .Include(k => k.Kreis)
                .Include(c => c.Ageclass)

                .ToList();
        }

        // GET: api/Dogowners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dogowner>> GetDogowner(int id)
        {
            var dogowner = _context.Dogowner
                .Where(x => x.Id == id)
                .Where(q => q.Id == id)
                .Where(k => k.Id == id)
                .Where(c => c.Id == id)

                .Include(x => x.Sex)
                .Include(q => q.Quartier)
                .Include(k => k.Kreis)
                .Include(c => c.Ageclass)

                .Single();

            if (dogowner == null)
            {
                return NotFound();
            }

            return dogowner;
        }

        // PUT: api/Dogowners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogowner(int id, Dogowner dogowner)
        {
            if (id != dogowner.Id)
            {
                return BadRequest();
            }

            _context.Entry(dogowner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogownerExists(id))
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

        // POST: api/Dogowners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dogowner>> PostDogowner(Dogowner dogowner)
        {
            _context.Dogowner.Add(dogowner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDogowner", new { id = dogowner.Id }, dogowner);
        }

        // DELETE: api/Dogowners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogowner(int id)
        {
            var dogowner = await _context.Dogowner.FindAsync(id);
            if (dogowner == null)
            {
                return NotFound();
            }

            _context.Dogowner.Remove(dogowner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DogownerExists(int id)
        {
            return _context.Dogowner.Any(e => e.Id == id);
        }
    }
}
