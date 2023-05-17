using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using comuneApi.Models;

namespace comuneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class beneficiesController : ControllerBase
    {
        private readonly DBContext _context;

        public beneficiesController(DBContext context)
        {
            _context = context;
        }
        //api/search?Name=...
        public async Task<IEnumerable<beneficie>> Search(string Name)
        {
            IQueryable<beneficie> query = _context.beneficies;

            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(e => e.Name.Contains(Name));
            }

            return await query.ToListAsync();
        }

        // GET: api/beneficies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<beneficie>>> Getbeneficies()
        {
            return await _context.beneficies.ToListAsync();
        }

        // GET: api/beneficies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<beneficie>> Getbeneficie(Guid id)
        {
            var beneficie = await _context.beneficies.FindAsync(id);

            if (beneficie == null)
            {
                return NotFound();
            }

            return beneficie;
        }

        // PUT: api/beneficies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbeneficie(Guid id, beneficie beneficie)
        {
            if (id != beneficie.Id)
            {
                return BadRequest();
            }

            _context.Entry(beneficie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!beneficieExists(id))
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

        // POST: api/beneficies
        
        [HttpPost]
        public async Task<ActionResult<beneficie>> Postbeneficie(beneficie beneficie)
        {
            _context.beneficies.Add(beneficie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getbeneficie", new { id = beneficie.Id }, beneficie);
        }

        // DELETE: api/beneficies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletebeneficie(Guid id)
        {
            var beneficie = await _context.beneficies.FindAsync(id);
            if (beneficie == null)
            {
                return NotFound();
            }

            _context.beneficies.Remove(beneficie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool beneficieExists(Guid id)
        {
            return _context.beneficies.Any(e => e.Id == id);
        }
    }
}
