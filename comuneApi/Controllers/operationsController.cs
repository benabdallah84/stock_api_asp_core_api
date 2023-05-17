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
    public class operationsController : ControllerBase
    {
        private readonly DBContext _context;

        public operationsController(DBContext context)
        {
            _context = context;
        }

        //api/search?titre=...
        public async Task<IEnumerable<operation>> Search(string titre)
        {
            IQueryable<operation> query = _context.operations;

            if (!string.IsNullOrEmpty(titre))
            {
                query = query.Where(e => e.titre.Contains(titre));
            }

            return await query.ToListAsync();
        }

        // GET: api/operations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<operation>>> Getoperations()
        {
            return await _context.operations.ToListAsync();
        }

        // GET: api/operations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<operation>> Getoperation(Guid id)
        {
            var operation = await _context.operations.FindAsync(id);

            if (operation == null)
            {
                return NotFound();
            }

            return operation;
        }

        // PUT: api/operations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putoperation(Guid id, operation operation)
        {
            if (id != operation.Id)
            {
                return BadRequest();
            }

            _context.Entry(operation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!operationExists(id))
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

        // POST: api/operations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<operation>> Postoperation(operation operation)
        {
            _context.operations.Add(operation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getoperation", new { id = operation.Id }, operation);
        }

        // DELETE: api/operations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteoperation(Guid id)
        {
            var operation = await _context.operations.FindAsync(id);
            if (operation == null)
            {
                return NotFound();
            }

            _context.operations.Remove(operation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool operationExists(Guid id)
        {
            return _context.operations.Any(e => e.Id == id);
        }
    }
}
