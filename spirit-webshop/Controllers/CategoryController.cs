using System.Collections.Generic;
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
                .Include(c => c.ProductCategories)
                .ThenInclude(pc => pc.Product)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            var result = await _context.Category
                .Include(c => c.ProductCategories)
                .ThenInclude(pc => pc.Product)
                .SingleOrDefaultAsync(c => c.Id == id);

            if (result == null) return NotFound();

            return result;
        }
    }
}