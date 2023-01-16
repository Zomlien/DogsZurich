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
    public class AgeclassesController : ControllerBase
    {
        private readonly DogContext _context;

        public AgeclassesController(DogContext context)
        {
            _context = context;
        }

        // GET: api/Ageclasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ageclass>>> GetAgeclass()
        {
            return await _context.Ageclass.ToListAsync();
        }

        // GET: api/Ageclasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ageclass>> GetAgeclass(int id)
        {
            var ageclass = await _context.Ageclass.FindAsync(id);

            if (ageclass == null)
            {
                return NotFound();
            }

            return ageclass;
        }

        // PUT: api/Ageclasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgeclass(int id, Ageclass ageclass)
        {
            if (id != ageclass.Id)
            {
                return BadRequest();
            }

            _context.Entry(ageclass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgeclassExists(id))
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

        // POST: api/Ageclasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ageclass>> PostAgeclass(Ageclass ageclass)
        {
            _context.Ageclass.Add(ageclass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgeclass", new { id = ageclass.Id }, ageclass);
        }

        // DELETE: api/Ageclasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgeclass(int id)
        {
            var ageclass = await _context.Ageclass.FindAsync(id);
            if (ageclass == null)
            {
                return NotFound();
            }

            _context.Ageclass.Remove(ageclass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgeclassExists(int id)
        {
            return _context.Ageclass.Any(e => e.Id == id);
        }
    }
}
