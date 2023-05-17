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
    public class fournisseursController : ControllerBase
    {
        private readonly DBContext _context;

        public fournisseursController(DBContext context)
        {
            _context = context;
        }

        //api/search?Name=...
        public async Task<IEnumerable<fournisseur>> Search(string Name)
        {
            IQueryable<fournisseur> query = _context.fournisseurs;

            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(e => e.Name.Contains(Name));
            }

            return await query.ToListAsync();
        }
        // GET: api/fournisseurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<fournisseur>>> Getfournisseurs()
        {
            return await _context.fournisseurs.ToListAsync();
        }

        // GET: api/fournisseurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<fournisseur>> Getfournisseur(Guid id)
        {
            var fournisseur = await _context.fournisseurs.FindAsync(id);

            if (fournisseur == null)
            {
                return NotFound();
            }

            return fournisseur;
        }

        // PUT: api/fournisseurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putfournisseur(Guid id, fournisseur fournisseur)
        {
            if (id != fournisseur.Id)
            {
                return BadRequest();
            }

            _context.Entry(fournisseur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!fournisseurExists(id))
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

        // POST: api/fournisseurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<fournisseur>> Postfournisseur(fournisseur fournisseur)
        {
            _context.fournisseurs.Add(fournisseur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getfournisseur", new { id = fournisseur.Id }, fournisseur);
        }

        // DELETE: api/fournisseurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletefournisseur(Guid id)
        {
            var fournisseur = await _context.fournisseurs.FindAsync(id);
            if (fournisseur == null)
            {
                return NotFound();
            }

            _context.fournisseurs.Remove(fournisseur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool fournisseurExists(Guid id)
        {
            return _context.fournisseurs.Any(e => e.Id == id);
        }
    }
}
