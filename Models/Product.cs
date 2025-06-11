namespace MiniStokTakipAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Unit { get; set; } = null!;
        public decimal TotalStock { get; set; }

        // Koleksiyon null olmasın diye başlatıyoruz
        public ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();
    }
}
