namespace GestionCarniceria.Core.Entities
{
    public class TransactionDetail : BaseEntity
    {

        public int? PurchaseId { get; set; }
        public Purchase? Purchase { get; set; }
        public int? SaleId { get; set; }
        public Sale? Sale { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public double QuantityInKg { get; set; }
        public decimal PricePerKg { get; set; }
    }
}
