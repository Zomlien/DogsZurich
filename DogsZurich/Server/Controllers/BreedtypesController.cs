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
    public class BreedtypesController : ControllerBase
    {
        private readonly DogContext _context;

        public BreedtypesController(DogContext context)
        {
            _context = context;
        }

        // GET: api/Breedtypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Breedtype>>> GetBreedtype()
        {
            return await _context.Breedtype.ToListAsync();
        }

        // GET: api/Breedtypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Breedtype>> GetBreedtype(int id)
        {
            var breedtype = await _context.Breedtype.FindAsync(id);

            if (breedtype == null)
            {
                return NotFound();
            }

            return breedtype;
        }

        // PUT: api/Breedtypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBreedtype(int id, Breedtype breedtype)
        {
            if (id != breedtype.Id)
            {
                return BadRequest();
            }

            _context.Entry(breedtype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreedtypeExists(id))
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

        // POST: api/Breedtypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Breedtype>> PostBreedtype(Breedtype breedtype)
        {
            _context.Breedtype.Add(breedtype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBreedtype", new { id = breedtype.Id }, breedtype);
        }

        // DELETE: api/Breedtypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreedtype(int id)
        {
            var breedtype = await _context.Breedtype.FindAsync(id);
            if (breedtype == null)
            {
                return NotFound();
            }

            _context.Breedtype.Remove(breedtype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BreedtypeExists(int id)
        {
            return _context.Breedtype.Any(e => e.Id == id);
        }
    }
}
