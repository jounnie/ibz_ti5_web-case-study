using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spirit_webshop.Entities;

namespace spirit_webshop.Controllers
{
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly SpiritDbContext _context;

        public ProductController(SpiritDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _context.Product.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var result = await _context.Product.FindAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }
    }
}