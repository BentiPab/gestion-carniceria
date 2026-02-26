namespace GestionCarniceria.Core.Entities
{
    public class PriceHistory : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public decimal PricePerKg { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
