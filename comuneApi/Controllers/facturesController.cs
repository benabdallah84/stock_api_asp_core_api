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
    public class facturesController : ControllerBase
    {
        private readonly DBContext _context;

        public facturesController(DBContext context)
        {
            _context = context;
        }

        //api/search?Num_facture=...
        public async Task<IEnumerable<facture>> Search(string Num_facture)
        {
            IQueryable<facture> query = _context.factures;

            if (!string.IsNullOrEmpty(Num_facture))
            {
                query = query.Where(e => e.Num_facture.Contains(Num_facture));
            }

            return await query.ToListAsync();
        }

        // GET: api/factures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<facture>>> Getfactures()
        {
            return await _context.factures.ToListAsync();
        }

        // GET: api/factures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<facture>> Getfacture(Guid id)
        {
            var facture = await _context.factures.FindAsync(id);

            if (facture == null)
            {
                return NotFound();
            }

            return facture;
        }

        // PUT: api/factures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putfacture(Guid id, facture facture)
        {
            if (id != facture.Id)
            {
                return BadRequest();
            }

            _context.Entry(facture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!factureExists(id))
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

        // POST: api/factures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<facture>> Postfacture(facture facture)
        {
            _context.factures.Add(facture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getfacture", new { id = facture.Id }, facture);
        }

        // DELETE: api/factures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletefacture(Guid id)
        {
            var facture = await _context.factures.FindAsync(id);
            if (facture == null)
            {
                return NotFound();
            }

            _context.factures.Remove(facture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool factureExists(Guid id)
        {
            return _context.factures.Any(e => e.Id == id);
        }
    }
}
