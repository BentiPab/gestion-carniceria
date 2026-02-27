namespace GestionCarniceria.Core.Entities
{
    public class PriceAgreement : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public Guid? BranchId { get; set; }
        public Branch? Branch { get; set; }
        public Guid? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }


        public decimal AgreedPricePerKg { get; set; }

        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }

    }
}
