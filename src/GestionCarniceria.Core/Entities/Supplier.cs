namespace GestionCarniceria.Core.Entities
{
    public class Supplier : BaseEntity
    {
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
        public ICollection<PriceAgreement> PriceList { get; set; } = new List<PriceAgreement>();
    }
}
