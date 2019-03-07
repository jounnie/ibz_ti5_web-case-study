using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spirit_webshop.Entities;

namespace spirit_webshop.Controllers
{
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private readonly SpiritDbContext _context;

        public CategoryController(SpiritDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return await _context.Category
                //.Include(c => c.ProductCategories)
                //.ThenInclude(pc => pc.Product)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            var result = await _context.Category
                .Include(c => c.InverseParentCategoryNavigation)
                //.ThenInclude(pc => pc.Product)
                .SingleOrDefaultAsync(c => c.Id == id);

            if (result == null) return NotFound();

            return result;
        }
        
        [HttpPost]
        public async Task<ActionResult<Category>> Create([FromBody] Category item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Category.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new {id = item.Id}, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Category item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != item.Id) return BadRequest("request id and item id not equal");

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Category.FindAsync(id);

            if (category == null) return NotFound();

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}