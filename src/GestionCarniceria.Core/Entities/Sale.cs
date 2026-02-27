namespace GestionCarniceria.Core.Entities
{
    public class Sale : BaseEntity
    {

        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid BuyerId { get; set; }
        public Branch Buyer { get; set; } = null!;
        public string TruckLicensePlate { get; set; } = string.Empty;

        public ICollection<TransactionDetail> SaleDetails { get; set; } = new List<TransactionDetail>();
    }
}
