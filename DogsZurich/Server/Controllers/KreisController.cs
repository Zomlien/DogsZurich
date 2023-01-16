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
    public class KreisController : ControllerBase
    {
        private readonly DogContext _context;

        public KreisController(DogContext context)
        {
            _context = context;
        }

        // GET: api/Kreis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kreis>>> GetKreis()
        {
            return await _context.Kreis.ToListAsync();
        }

        // GET: api/Kreis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kreis>> GetKreis(int id)
        {
            var kreis = await _context.Kreis.FindAsync(id);

            if (kreis == null)
            {
                return NotFound();
            }

            return kreis;
        }

        // PUT: api/Kreis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKreis(int id, Kreis kreis)
        {
            if (id != kreis.Id)
            {
                return BadRequest();
            }

            _context.Entry(kreis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KreisExists(id))
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

        // POST: api/Kreis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kreis>> PostKreis(Kreis kreis)
        {
            _context.Kreis.Add(kreis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKreis", new { id = kreis.Id }, kreis);
        }

        // DELETE: api/Kreis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKreis(int id)
        {
            var kreis = await _context.Kreis.FindAsync(id);
            if (kreis == null)
            {
                return NotFound();
            }

            _context.Kreis.Remove(kreis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KreisExists(int id)
        {
            return _context.Kreis.Any(e => e.Id == id);
        }
    }
}
