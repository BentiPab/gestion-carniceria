namespace GestionCarniceria.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal PricePerKg { get; set; }
        public int StockInKg { get; set; }
        public string Category { get; set; } = string.Empty;
        public int SalePrice { get; set; }
        public ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
        public ICollection<PriceList> PriceLists { get; set; } = new List<PriceList>();
        public ICollection<PriceHistory> PriceHistory { get; set; } = new List<PriceHistory>();

    }
}
