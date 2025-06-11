using System.Text.Json.Serialization;

namespace MiniStokTakipAPI.Models
{
    public class StockTransaction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public string Type { get; set; } = null!; // "IN" veya "OUT"
        public DateTime Date { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

    }
}
