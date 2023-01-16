﻿using System;
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
    public class DogsController : ControllerBase
    {
        private readonly DogContext _context;

        public DogsController(DogContext context)
        {
            _context = context;
        }

        // GET: api/Dogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dog>>> GetDogs()
        {
            return _context.Dogs
                .Include(s => s.Breedstatus)
                .Include(t => t.Breedtype)
                .Include(c => c.Colors)
                .Include(x => x.Sex)
                .Include(b => b.Breed1)
                .Include(a => a.Breed2)
                .Include(o => o.Dogowner)
                .ToList();

        }

        // GET: api/Dogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dog>> GetDog(int id)
        {
            //var dog = await _context.Dogs.FindAsync(id);
            Dog dog = _context.Dogs
                .Where(s => s.Id == id)
                .Where(t => t.Id == id)
                .Where(c => c.Id == id)
                .Where(x => x.Id == id)
                .Where(b => b.Id == id)
                .Where(a => a.Id == id)
                .Where(o => o.Id == id)
                .Include(s => s.Breedstatus)
                .Include(t => t.Breedtype)
                .Include(c => c.Colors)
                .Include(x => x.Sex)
                .Include(b => b.Breed1)
                .Include(a => a.Breed2)
                .Include(o => o.Dogowner)
                .Single();

            if (dog == null)
            {
                return NotFound();
            }

            return dog;
        }

        // PUT: api/Dogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDog(int id, Dog dog)
        {
            if (id != dog.Id)
            {
                return BadRequest();
            }

            _context.Entry(dog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogExists(id))
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

        // POST: api/Dogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dog>> PostDog(Dog dog)
        {
            //Dog newDog = ConvertToNewDog(dog);
            _context.Dogs.Add(dog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDog", new { id = dog.Id }, dog);
        }

        // DELETE: api/Dogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDog(int id)
        {
            var dog = await _context.Dogs.FindAsync(id);
            if (dog == null)
            {
                return NotFound();
            }

            _context.Dogs.Remove(dog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DogExists(int id)
        {
            return _context.Dogs.Any(e => e.Id == id);
        }

        //private Dog ConvertToNewDog(Dog dogGiven)
        //{
        //    var dog = _context.Dogs
        //    .Where(p => p.Id == dogGiven.Id)
        //    .Include("Species")
        //    .SingleOrDefault();
        //    if (dog != null)
        //    {
        //        dog.Name = dogGiven.Name;
        //        dog.Species.Clear();
        //    }
        //    else
        //    {
        //        dog = new Starship()
        //        {
        //            Id = dogGiven.Id,
        //            Name = dogGiven.Name,
        //            Builddate = starshipGiven.Builddate,
        //            length = starshipGiven.length,
        //            CargoSpace = starshipGiven.CargoSpace,
        //            //ShipClass = null,
        //            ShipClassId = starshipGiven.ShipClassId,
        //            //ShipClass = new List<ShipClass>(),
        //            Species = new List<Species>()
        //        };
        //    }
        //    //foreach (ShipClass shipclass in starshipGiven.Shipclass)
        //    //{
        //    //    starship.Species.Add(_context.Species.Find(species.Id));
        //    //}
        //    foreach (Species species in starshipGiven.Species)
        //    {
        //        Species speciesfromDB = _context.Species.Find(species.Id);
        //        starship.Species.Add(speciesfromDB);
        //    }
        //    return starship;
        //}
    }
}
