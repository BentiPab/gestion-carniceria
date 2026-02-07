namespace GestionCarniceria.Core.Entities
{
    public class Sale : BaseEntity
    {

        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;

        public ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
    }
}
