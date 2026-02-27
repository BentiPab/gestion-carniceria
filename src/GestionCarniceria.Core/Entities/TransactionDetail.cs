namespace GestionCarniceria.Core.Entities
{
    public class TransactionDetail : BaseEntity
    {

        public Guid? PurchaseId { get; set; }
        public Purchase? Purchase { get; set; }
        public Guid? SaleId { get; set; }
        public Sale? Sale { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public double QuantityInKg { get; set; }
        public decimal PricePerKg { get; set; }
    }
}
