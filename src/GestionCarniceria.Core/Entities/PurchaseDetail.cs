namespace GestionCarniceria.Core.Entities
{
    public class PurchaseDetail : BaseEntity
    {

        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; } = null!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public double QuantityInKg { get; set; }
        public decimal PricePerKg { get; set; }
    }
}
