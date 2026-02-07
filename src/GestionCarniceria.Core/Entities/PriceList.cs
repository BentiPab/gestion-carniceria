namespace GestionCarniceria.Core.Entities
{
    public class PriceList : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int BusinessPartnerId { get; set; }
        public BusinessPartner BusinessPartner { get; set; } = null!;

        public decimal AgreedPricePerKg { get; set; }

        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }

    }
}
