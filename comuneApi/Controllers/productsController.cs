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
    public class productsController : ControllerBase
    {
        private readonly DBContext _context;

        public productsController(DBContext context)
        {
            _context = context;
        }

        //api/search?Matricul=..&productType=...
        public async Task<IEnumerable<product>> Search(string Matricul, Models.Type? productType)
        {
            IQueryable<product> query = _context.products;

            if (!string.IsNullOrEmpty(Matricul))
            {
                query = query.Where(e => e.Matricul.Contains(Matricul)
                            || e.Designation.Contains(Matricul));
            }

            if (productType != null)
            {
                query = query.Where(e => e.productType == productType);
            }

            return await query.ToListAsync();
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<product>>> Getproducts()
        {
            return await _context.products.ToListAsync();
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<product>> Getproduct(Guid id)
        {
            var product = await _context.products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproduct(Guid id, product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productExists(id))
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

        // POST: api/products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<product>> Postproduct(product product)
        {
            _context.products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproduct", new { id = product.Id }, product);
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproduct(Guid id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool productExists(Guid id)
        {
            return _context.products.Any(e => e.Id == id);
        }
    }
}
