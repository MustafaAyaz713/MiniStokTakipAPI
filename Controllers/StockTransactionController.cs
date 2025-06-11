using Microsoft.AspNetCore.Mvc;
using MiniStokTakipAPI.Data;
using MiniStokTakipAPI.Models;

namespace MiniStokTakipAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockTransactionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StockTransactionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/stocktransaction/product/3
        [HttpGet("product/{productId}")]
        public IActionResult GetByProduct(int productId)
        {
            var transactions = _context.StockTransactions
                .Where(t => t.ProductId == productId)
                .OrderByDescending(t => t.Date)
                .ToList();

            return Ok(transactions);
        }

        // POST: api/stocktransaction
        [HttpPost]
        public IActionResult Create(StockTransaction transaction)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == transaction.ProductId);
            if (product == null)
                return BadRequest("Ürün bulunamadı.");

            if (transaction.Type == "OUT" && product.TotalStock < transaction.Quantity)
                return BadRequest("Yeterli stok yok.");

            // Stok güncellemesi
            if (transaction.Type == "IN")
                product.TotalStock += transaction.Quantity;
            else if (transaction.Type == "OUT")
                product.TotalStock -= transaction.Quantity;
            else
                return BadRequest("Type sadece 'IN' veya 'OUT' olabilir.");

            _context.StockTransactions.Add(transaction);
            _context.SaveChanges();

            return Ok(transaction);
        }
    }
}
