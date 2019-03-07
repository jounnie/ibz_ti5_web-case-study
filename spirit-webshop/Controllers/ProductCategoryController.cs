using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spirit_webshop.Entities;

namespace spirit_webshop.Controllers
{
    [Route("api/categories")]
    public class ProductCategoryController : Controller
    {
        private readonly SpiritDbContext _context;

        public ProductCategoryController(SpiritDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/products")]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProducts(int id)
        {
            var result = await _context.ProductCategory.Where(p => p.FkCategory == id).ToListAsync();

            if (result == null) return NotFound();

            return result;
        }

        [HttpPost("{id}/products")]
        public async Task<ActionResult<ProductCategory>> Create([FromBody] ProductCategory item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.ProductCategory.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducts), new {id = item.Id}, item);
        }

        [HttpDelete("{id}/products/{pid}")]
        public async Task<IActionResult> Delete(int id, int pid)
        {
            var product = await _context.ProductCategory.Where(pc => pc.FkCategory == id && pc.FkProduct == pid).SingleAsync();

            if (product == null) return NotFound();

            _context.ProductCategory.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}