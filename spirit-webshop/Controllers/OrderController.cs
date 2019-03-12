using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spirit_webshop.Entities;

namespace spirit_webshop.Controllers
{
    [Route("api/orders")]
    public class OrderController : Controller
    {
        private readonly SpiritDbContext _context;

        public OrderController(SpiritDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            return await _context.Order
                .Include(o => o.Position)
                    .ThenInclude(p => p.FkProductNavigation)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            var result = await _context.Order
                .Include(o => o.Position)
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync();

            if (result == null) return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Create([FromBody] Order item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Order.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new {id = item.Id}, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Order item)
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
            var order = await _context.Order
                .Include(o => o.Position)
                .Where(o => o.Id == id)
                .LastOrDefaultAsync();
            if (order == null) return NotFound();

            foreach (var position in order.Position)
                _context.Position.Remove(position);

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}