using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spirit_webshop.Entities;

namespace spirit_webshop.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly SpiritDbContext _context;

        public UserController(SpiritDbContext context)
        {
            _context = context;
        }

        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _context.User
                //.Include(User => User.UserCategories)
                .ToListAsync();
        }*/

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var result = await _context.User.FindAsync(id);

            if (result == null) return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] User item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.User.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new {id = item.Id}, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] User item)
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
            var user = await _context.User.FindAsync(id);

            if (user == null) return NotFound();

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] LoginRequest loginRequest)
        {
            var user = await _context.User
                .Where(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password)
                .FirstOrDefaultAsync();

            if (user == null)
                return StatusCode(403);
            
            HttpContext.Session.SetString("email", user.Email); 
            HttpContext.Session.SetString("type", user.Type); 
            
            return Ok(new {isAdmin = "ADMIN".Equals(user.Type)});
        }
        
        [HttpPost("logout")]
        public OkResult Logout()
        {
            HttpContext.Session.Remove("email"); 
            HttpContext.Session.Remove("type"); 
            
            return Ok();
        }
        
        public class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }

        }
    }
}