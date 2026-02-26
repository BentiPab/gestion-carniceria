namespace GestionCarniceria.Core.Entities
{
    public class PriceAgreement : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int? BranchId { get; set; }
        public Branch? Branch { get; set; }
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }


        public decimal AgreedPricePerKg { get; set; }

        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }

    }
}
