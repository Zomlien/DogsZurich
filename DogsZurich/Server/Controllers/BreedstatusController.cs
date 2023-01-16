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
    public class BreedstatusController : ControllerBase
    {
        private readonly DogContext _context;

        public BreedstatusController(DogContext context)
        {
            _context = context;
        }

        // GET: api/Breedstatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Breedstatus>>> GetBreedstatus()
        {
            return await _context.Breedstatus.ToListAsync();
        }

        // GET: api/Breedstatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Breedstatus>> GetBreedstatus(int id)
        {
            var breedstatus = await _context.Breedstatus.FindAsync(id);

            if (breedstatus == null)
            {
                return NotFound();
            }

            return breedstatus;
        }

        // PUT: api/Breedstatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBreedstatus(int id, Breedstatus breedstatus)
        {
            if (id != breedstatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(breedstatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreedstatusExists(id))
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

        // POST: api/Breedstatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Breedstatus>> PostBreedstatus(Breedstatus breedstatus)
        {
            _context.Breedstatus.Add(breedstatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBreedstatus", new { id = breedstatus.Id }, breedstatus);
        }

        // DELETE: api/Breedstatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreedstatus(int id)
        {
            var breedstatus = await _context.Breedstatus.FindAsync(id);
            if (breedstatus == null)
            {
                return NotFound();
            }

            _context.Breedstatus.Remove(breedstatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BreedstatusExists(int id)
        {
            return _context.Breedstatus.Any(e => e.Id == id);
        }
    }
}
