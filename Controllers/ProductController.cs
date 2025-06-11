using Microsoft.AspNetCore.Mvc;
using MiniStokTakipAPI.Data;
using MiniStokTakipAPI.Models;

namespace MiniStokTakipAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/product
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        // GET: api/product/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST: api/product
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (_context.Products.Any(p => p.Code == product.Code))
                return BadRequest("Bu ürün kodu zaten kullanılıyor.");

            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }
    }
}
