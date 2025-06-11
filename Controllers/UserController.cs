using Microsoft.AspNetCore.Mvc;
using MiniStokTakipAPI.Data;
using MiniStokTakipAPI.Models;

namespace MiniStokTakipAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/user
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        // POST: api/user/register
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
                return BadRequest("Bu e-posta adresi zaten kayıtlı.");

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        // POST: api/user/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] User login)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);

            if (user == null)
                return Unauthorized("Geçersiz e-posta veya şifre.");

            return Ok("Giriş başarılı");
        }
    }
}
