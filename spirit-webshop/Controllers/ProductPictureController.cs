using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spirit_webshop.Entities;

namespace spirit_webshop.Controllers
{
    [Route("api/products")]
    public class ProductPictureController : Controller
    {
        private readonly SpiritDbContext _context;

        public ProductPictureController(SpiritDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/pictures")]
        public async Task<ActionResult<IEnumerable<ProductPicture>>> GetPictures(int id)
        {
            var result = await _context.ProductPicture.Where(p => p.FkProduct == id).ToListAsync();

            if (result == null) return NotFound();

            return result;
        }

        [HttpPost("{id}/pictures")]
        public async Task<ActionResult<Product>> Create(int id, [FromBody] ProductPicture item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.ProductPicture.Add(new ProductPicture {FkProduct = id, Base64 = item.Base64});
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}/pictures/{pid}")]
        public async Task<IActionResult> Delete(int id, int pid)
        {
            var product = await _context.ProductPicture.Where(pp => pp.FkProduct== id && pp.Id== pid).SingleAsync();

            if (product == null) return NotFound();

            _context.ProductPicture.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}