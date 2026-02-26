namespace GestionCarniceria.Core.Entities
{
    public class Purchase : BaseEntity
    {
        public int PurchaseNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;

        public ICollection<TransactionDetail> PurchaseDetails { get; set; } = new List<TransactionDetail>();
    }
}
