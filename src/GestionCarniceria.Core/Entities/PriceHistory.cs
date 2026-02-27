namespace GestionCarniceria.Core.Entities
{
    public class PriceHistory : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public decimal PricePerKg { get; set; }
    }
}
