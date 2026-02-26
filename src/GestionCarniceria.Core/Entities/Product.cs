namespace GestionCarniceria.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal PricePerKg { get; set; }
        public int StockInKg { get; set; }
        public string Category { get; set; } = string.Empty;
        public int SalePrice { get; set; }
        public ICollection<TransactionDetail> PurchaseDetails { get; set; } = new List<TransactionDetail>();
        public ICollection<PriceAgreement> PriceLists { get; set; } = new List<PriceAgreement>();
        public ICollection<PriceHistory> PriceHistory { get; set; } = new List<PriceHistory>();

    }
}
